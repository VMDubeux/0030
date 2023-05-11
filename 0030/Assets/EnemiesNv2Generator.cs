using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesNv2Generator : MonoBehaviour
{
    public GameObject EnemyNv2;
    [SerializeField] private float _timeToGenerate = 7;
    private float _timeCounter = 0;

    void Start()
    {

    }

    void Update()
    {
        _timeCounter += Time.deltaTime;

        if (_timeCounter >= _timeToGenerate)
        {
            Instantiate(EnemyNv2, transform.position, EnemyNv2.transform.rotation);
            _timeCounter = 0;
        }
    }
}
