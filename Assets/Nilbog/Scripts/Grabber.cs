using System;
using System.Runtime.CompilerServices;
using UnityEditor.VersionControl;
using UnityEditorInternal;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Grabber : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 _startPos;
    private Vector2 _finalPos;
    private GameObject _selectedObject;

    /*[Header("Elements:")]
    private Transform toDrag;
    private Rigidbody toDragRigidbody;
    private bool touched = false;
    private bool dragging = false;
    private float posX;
    private float posY;
    private Vector3 dist;
    private Vector3 previousPosition;



    [Header("Settup:")]
    [SerializeField] private Camera _mainCam;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private string DraggingTag;*/

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            RaycastHit hit = CastRay();

            if (hit.collider.CompareTag("drag"))
            {
                _selectedObject = hit.collider.gameObject;

                Debug.Log("Acertou o objeto");

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _startPos = touch.position;
                        Debug.Log("Começou");
                        break;

                    case TouchPhase.Moved:
                        Vector3 position = new(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.WorldToScreenPoint(_selectedObject.transform.position).z);
                        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                        _selectedObject.transform.position = new Vector3(worldPosition.x, 0.5f, worldPosition.z);
                        Debug.Log("Movendo");
                        break;

                    case TouchPhase.Ended:
                        Debug.Log("Terminou");
                        break;
                }
            }
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenTouchPosFar = new(
            Input.GetTouch(0).position.x,
            Input.GetTouch(0).position.y,
            Camera.main.farClipPlane);
        Vector3 screenTouchPosNear = new(
            Input.GetTouch(0).position.x,
            Input.GetTouch(0).position.y,
            Camera.main.nearClipPlane);
        Vector3 worldTouchPosFar = Camera.main.ScreenToWorldPoint(screenTouchPosFar);
        Vector3 worldTouchPosNear = Camera.main.ScreenToWorldPoint(screenTouchPosNear);
        RaycastHit hit;
        Physics.Raycast(worldTouchPosNear, worldTouchPosFar - worldTouchPosNear, out hit);

        return hit;
    }
}
