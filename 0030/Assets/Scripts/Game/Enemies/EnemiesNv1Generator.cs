using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesNv1Generator : MonoBehaviour
{
    public GameObject EnemyNv1;
    public float TimeToGenerate = 3;
    private float _timeCounter = 0;

    void Start()
    {

    }

    void Update()
    {
        _timeCounter += Time.deltaTime;

        if (_timeCounter >= TimeToGenerate)
        {
            Instantiate(EnemyNv1, transform.position, EnemyNv1.transform.rotation);
            _timeCounter = 0;
        }
    }
}
