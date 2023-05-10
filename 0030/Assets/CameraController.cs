using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _cam;
    private Vector3 _camStartPosition;
    
    [Range(0.01f, 0.05f)]
    public float CameraSpeed;

    void Start()
    {
        _cam = Camera.main.transform;
        _camStartPosition = _cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, 0) * CameraSpeed;
    }
}
