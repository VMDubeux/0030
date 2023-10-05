using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Verification))]
public class Draggable : MonoBehaviour
{
    private Vector3 _startPosition = Vector3.zero;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("target"))
        {
            Debug.Log("Vitória");
            Destroy(gameObject);
        }
    }

    public void ResetPosition()
    {
        if (transform.position.x != _startPosition.x || transform.position.z != _startPosition.z)
            transform.position = _startPosition;
    }
}
