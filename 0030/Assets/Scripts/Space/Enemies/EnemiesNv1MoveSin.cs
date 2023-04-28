using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesNv1MoveSin : MonoBehaviour
{
    public float Amplitude = 40.0f;
    public float Frequency = 0.05f;
    public bool Inverted = false;
    private float _sinCenterY;

    void Start()
    {
        _sinCenterY = transform.position.y;
    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        float sin = Mathf.Sin(position.x * Frequency) * Amplitude;
        if (Inverted)
            sin *= -1;
        position.y = _sinCenterY + sin;
        transform.position = position;
    }
}
