using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesControllerNv2 : MonoBehaviour
{
    [SerializeField] private float _frequency;
    [SerializeField] private float _amplitude;
    Vector3 StartPosition;

    private void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(14.5f, Mathf.Sin(Time.time * _frequency) * _amplitude + StartPosition.y, 7);
    }
}
