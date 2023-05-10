using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MarsParallax : MonoBehaviour
{
    private Transform _cam;
    //private Vector3 _camStartPosition; //Usar se a camera tiver de seguir o player
    //private float _distance; //Usar se a camera tiver de seguir o player

    private GameObject[] _backgrounds;
    private Material[] _mat;
    private float[] _backSpeed;

    private float _farthestBackground;

    [Range(0.01f, 0.05f)]
    public float ParallaxSpeed;

    public float SpeedSideScrooling = 35.0f;

    void Start()
    {
        _cam = Camera.main.transform;
        //_camStartPosition = _cam.position; //Usar se a camera tiver de seguir o player

        int _backCount = transform.childCount;
        _mat = new Material[_backCount];
        _backSpeed = new float[_backCount];
        _backgrounds = new GameObject[_backCount];

        for (int i = 0; i < _backCount; i++)
        {
            _backgrounds[i] = transform.GetChild(i).gameObject;
            _mat[i] = _backgrounds[i].GetComponent<Renderer>().material;
        }
        BackSpeedCalculate(_backCount);
    }

    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++) //encontrar o background mais distante
        {
            if (_backgrounds[i].transform.position.z - _cam.position.z > _farthestBackground)
                _farthestBackground = _backgrounds[i].transform.position.z - _cam.position.z;
        }

        for (int i = 0; i < backCount; i++) // definir a velocidade do background
        {
            _backSpeed[i] = 1 - (_backgrounds[i].transform.position.z - _cam.position.z) / _farthestBackground;
        }
    }

    private void LateUpdate()
    {
        //_distance = _cam.position.x - _camStartPosition.x; //Usar se a camera tiver de seguir o player
        //transform.position = new Vector3(_cam.position.x, transform.position.y, 0); //Usar se a camera tiver de seguir o player

        for (int i = 0; i < _backgrounds.Length; i++)
        { 
            float _speed2 = _backSpeed[i] * ParallaxSpeed;
            _mat[i].mainTextureOffset += new Vector2(SpeedSideScrooling * Time.deltaTime, 0) * _speed2;
            //_mat[i].SetTextureOffset("_MainTex", new Vector2(_distance, 0) * _speed2); //Usar se a camera tiver de seguir o player
        }
    }
}