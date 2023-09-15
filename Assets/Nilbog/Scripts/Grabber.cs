using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEditorInternal;
using UnityEngine;
using System.Collections;
using static UnityEditor.PlayerSettings;

public class Grabber : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 _startPos;
    private Vector2 _finalPos;
    private GameObject _selectedObject;
    private bool _fingerIsDown;
    private bool _onTarget;
    [SerializeField] private LayerMask _layerMask;

    private void Start()
    {
        _fingerIsDown = false;
    }

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
                        if (_fingerIsDown == false)
                        {
                            Debug.Log("Começou");
                            _fingerIsDown = true;
                        }
                        break;

                    case TouchPhase.Stationary:
                        if (_fingerIsDown)
                        {
                            if (_selectedObject.transform.position.y <= 4.0f)
                                _selectedObject.transform.position = Vector3.Lerp(_selectedObject.transform.position, new Vector3(_selectedObject.transform.position.x, 5f, _selectedObject.transform.position.z), 0.9f * Time.deltaTime);
                            Debug.Log("Subindo");
                        }
                        break;

                    case TouchPhase.Moved:
                        if (_fingerIsDown)
                        {
                            Debug.Log("Movendo");
                            if (_selectedObject.transform.position.z <= 6.3f)
                            {
                                Vector3 position = new(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.WorldToScreenPoint(_selectedObject.transform.position).z);
                                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                                _selectedObject.transform.position = new Vector3(worldPosition.x, _selectedObject.transform.position.y, worldPosition.z);
                            }
                        }
                        break;

                    case TouchPhase.Ended:
                        Debug.Log("Terminou");
                        _selectedObject.GetComponent<Draggable>().ResetPosition();
                        _fingerIsDown = false;
                        break;

                    case TouchPhase.Canceled:
                        Debug.Log("Cancelado");
                        _selectedObject.GetComponent<Draggable>().ResetPosition();
                        _fingerIsDown = false;
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
        Physics.Raycast(worldTouchPosNear, worldTouchPosFar - worldTouchPosNear, out hit, int.MaxValue, _layerMask);

        return hit;
    }
}
