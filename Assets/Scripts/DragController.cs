using UnityEngine;
using UnityEngine.EventSystems;

public class DragController : Singleton<DragController>
{
    private bool _isDragActive = false;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    private Draggable _lastDragged;
    private Camera _mainCamera;
    private float _leftBound;
    private float _topBound;
    private float _rightBound;
    private float _bottomBound;

    protected override void Awake()
    {
        base.Awake();
        _mainCamera = Camera.main;
    }

    //Code untuk membuat object/alat yang di drag tidak melewati camera seluruhnya
    private void Start()
    {
        _leftBound = _mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        _bottomBound = _mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        _rightBound = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        _topBound = _mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
    }

    //Code untuk membuat object/alat bisa di drag oleh touch/mouse
    private void Update()
    {
        if(_isDragActive && (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Drop();
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
            
        }
        else if (Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else return;

        _worldPosition = _mainCamera.ScreenToWorldPoint(_screenPosition);
        _worldPosition.z = 0;

        if (_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if(hit.collider != null) 
            {
                if (!hit.transform.TryGetComponent(out Draggable draggable)) return;
                _lastDragged = draggable;
                InitDrag();
            }
        }
    }

    private void InitDrag()
    {
        _isDragActive = true;
        if (!_lastDragged.TryGetComponent(out Draggable draggable)) return;
        draggable.OnClickObject();
    }

    private void Drag()
    {
        if (!_lastDragged.TryGetComponent(out BoxCollider2D boxCollider2D)) return;
        _lastDragged.transform.position = new Vector2(Mathf.Clamp(_worldPosition.x,_leftBound + boxCollider2D.bounds.size.x/2 ,_rightBound - boxCollider2D.bounds.size.x/2), Mathf.Clamp(_worldPosition.y, _bottomBound , _topBound));

    }

    private void Drop()
    {
        _isDragActive = false;
    }

    public void SetDragActiveToFalse()
    {
        _isDragActive = false;
    }

}
