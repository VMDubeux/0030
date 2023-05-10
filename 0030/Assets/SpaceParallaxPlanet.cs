using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceParallaxPlanet : MonoBehaviour
{
    private Transform _cam;

    private GameObject[] _backgrounds;
    private Material[] _mat;
    private float[] _backSpeed;

    private float _farthestBackground;

    [Range(0.001f, 0.05f)]
    public float ParallaxSpeed;

    public float SpeedSideScrooling = 35.0f;

    void Start()
    {
        _cam = Camera.main.transform;

        int _backCount = transform.childCount;
        _mat = new Material[_backCount];
        _backSpeed = new float[_backCount];
        _backgrounds = new GameObject[_backCount];

        _backgrounds[0] = transform.GetChild(0).gameObject;
        _mat[0] = _backgrounds[0].GetComponent<Renderer>().material;

        BackSpeedCalculate(_backCount);
    }

    void BackSpeedCalculate(int backCount)
    {

        if (_backgrounds[0].transform.position.z - _cam.position.z > _farthestBackground)
            _farthestBackground = _backgrounds[0].transform.position.z - _cam.position.z;

        _backSpeed[0] = 0.001f;
    }

    private void LateUpdate()
    {
        for (int i = 0; i < _backgrounds.Length; i++)
        {
            float _speed = _backSpeed[0] * ParallaxSpeed;
            _mat[0].mainTextureOffset += new Vector2(SpeedSideScrooling * Time.deltaTime, 0) * _speed;
        }
    }
}
