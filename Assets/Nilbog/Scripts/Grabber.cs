using UnityEngine;

public class Grabber : MonoBehaviour
{
    private GameObject _draggingObject;
    private bool _fingerIsDown;
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

            if (!_fingerIsDown)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null && hit.collider.CompareTag("drag"))
                {
                    _draggingObject = hit.collider.gameObject;
                    Debug.Log("Acertou o objeto");
                }
            }

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (_draggingObject != null)
                    {
                        Debug.Log("Começou");
                        _fingerIsDown = true;
                    }
                    break;

                case TouchPhase.Stationary:
                    if (_fingerIsDown)
                    {
                        if (_draggingObject.transform.position.y <= 4.0f)
                        {
                            _draggingObject.transform.position = Vector3.Lerp(
                                _draggingObject.transform.position,
                                new Vector3(0, 5f, _draggingObject.transform.position.z),
                                0.2f * Time.fixedDeltaTime);
                            Debug.Log("Subindo");
                        }
                    }
                    break;

                case TouchPhase.Moved:
                    if (_fingerIsDown && _draggingObject != null)
                    {
                        Debug.Log("Movendo");
                        Vector3 screenTouchPos = new Vector3(touch.position.x, touch.position.y, Camera.main.WorldToScreenPoint(_draggingObject.transform.position).z);
                        Vector3 worldTouchPos = Camera.main.ScreenToWorldPoint(screenTouchPos);
                        float clampedZ = Mathf.Clamp(worldTouchPos.z, float.MinValue, 6.7f);
                        _draggingObject.transform.position = new Vector3(worldTouchPos.x, _draggingObject.transform.position.y, clampedZ);
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (_fingerIsDown)
                    {
                        Debug.Log("Terminou");
                        _fingerIsDown = false;
                        _draggingObject = null;
                    }
                    break;
            }
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenTouchPosFar = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, Camera.main.farClipPlane);
        Vector3 screenTouchPosNear = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, Camera.main.nearClipPlane);
        Vector3 worldTouchPosFar = Camera.main.ScreenToWorldPoint(screenTouchPosFar);
        Vector3 worldTouchPosNear = Camera.main.ScreenToWorldPoint(screenTouchPosNear);
        RaycastHit hit;
        Physics.Raycast(worldTouchPosNear, worldTouchPosFar - worldTouchPosNear, out hit, float.MaxValue, _layerMask);

        return hit;
    }
}
