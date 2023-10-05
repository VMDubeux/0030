using UnityEngine;

public class Grabber : MonoBehaviour
{
    #region Public Fields
    [Header("SETTINGS")]
    public float timeToBecomeStationary = 1f;
    public LayerMask layerMask;
    #endregion

    #region Private Fields
    private GameObject _draggingObject;
    //private bool _fingerIsDown;
    private Vector2 _lastTouchPosition;
    private float _stationaryTime = 0f;
    private Camera _camera;
    #endregion

    private void OnEnable()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        //_fingerIsDown = false;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                case TouchPhase.Began:
                {
                    RaycastHit hit = CastRay();

                    if (hit.collider != null && hit.collider.CompareTag("drag"))
                        _draggingObject = hit.collider.gameObject;

                    _stationaryTime = 0;
                    break;
                }
                case TouchPhase.Stationary or TouchPhase.Moved:
                {
                    if (_draggingObject != null)
                    {
                        if (_stationaryTime >= timeToBecomeStationary)
                        {
                            if (_draggingObject.transform.position.y <= 4.0f)
                            {
                                var position = _draggingObject.transform.position;
                                position += new Vector3(0, Time.deltaTime * 2f, 0);
                                _draggingObject.transform.position = position;
                            }
                        }
                        else
                        {
                            var position = _draggingObject.transform.position;
                            Vector3 screenTouchPos = new(touch.position.x, touch.position.y, _camera.WorldToScreenPoint(position).z);
                            Vector3 worldTouchPos = _camera.ScreenToWorldPoint(screenTouchPos);
                            
                            float clampedZ = Mathf.Clamp(worldTouchPos.z, float.MinValue, 6.7f);
                            position = new Vector3(worldTouchPos.x, position.y, clampedZ);
                            _draggingObject.transform.position = position;
                        }
                        
                        if (Vector2.Distance(touch.position, _lastTouchPosition) < 5f)
                            _stationaryTime += Time.deltaTime;
                        else
                            _stationaryTime = 0;

                        _lastTouchPosition = touch.position;
                    }
                    break;
                }
                
                default:
                    if(_draggingObject != null)
                        _draggingObject.GetComponent<Draggable>().ResetPosition();
                    break;
            }
        }
    }
    
    private RaycastHit CastRay()
    {
        Vector3 screenTouchPosFar = new(Input.touches[0].position.x, Input.touches[0].position.y, _camera.farClipPlane);
        Vector3 screenTouchPosNear = new(Input.touches[0].position.x, Input.touches[0].position.y, _camera.nearClipPlane);
        Vector3 worldTouchPosFar = _camera.ScreenToWorldPoint(screenTouchPosFar);
        Vector3 worldTouchPosNear = _camera.ScreenToWorldPoint(screenTouchPosNear);
        Physics.Raycast(worldTouchPosNear, worldTouchPosFar - worldTouchPosNear, out RaycastHit hit, float.MaxValue, layerMask);

        return hit;
    }
}
