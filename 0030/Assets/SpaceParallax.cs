using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceParallax : MonoBehaviour
{
    private Transform _cam;

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
        for (int i = 0; i < _backgrounds.Length; i++)
        {
            float _speed = _backSpeed[i] * ParallaxSpeed;
            _mat[i].mainTextureOffset += new Vector2(SpeedSideScrooling * Time.deltaTime, 0) * _speed;
        }
    }
}
