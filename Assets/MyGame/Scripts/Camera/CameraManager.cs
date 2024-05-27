using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    private Camera _camera;
    private Vector2 _delta;
    private bool _isMoving;

    public float TimeOnScreen;
    public float OrthoZoomSpeed = 0.1f;
    public float ZoomMin = 2f;
    public float ZoomMax = 8f;
    public float DragMaxX = 50f;
    public float DragMaxZ = 50f;
    public float MovementSpeed = 10.0f;
    public float DampTime = 0.2f; // Damping time for movement
    public float ZoomDampTime = 0.25f; // Damping time for zooming

    private Vector3 _velocity = Vector3.zero; // Used for SmoothDamp
    private float _zoomVelocity = 0.0f; // Used for SmoothDamp for zooming
    private float _zoomMultiplier = 4f;
    private float _targetZoom;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _camera.orthographicSize = 45;
        _targetZoom = _camera.orthographicSize;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _delta = context.ReadValue<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _isMoving = context.performed;
    }

    private void LateUpdate()
    {
        HandleMovement();
        HandleZoom();
        ClampCameraPosition();
        ClampCameraZoom();
    }

    private void HandleMovement()
    {
        if (_isMoving)
        {
            Vector3 targetPosition = transform.position;
            targetPosition += transform.right * (_delta.x * -MovementSpeed * (_camera.orthographicSize / 60));
            targetPosition += transform.up * (_delta.y * -MovementSpeed * (_camera.orthographicSize / 60));

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, DampTime, Mathf.Infinity, Time.deltaTime);
        }
    }

    private void HandleZoom()
    {
        // Handle zoom with mouse scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.01f)
        {
            _targetZoom -= scroll * _zoomMultiplier;
            _targetZoom = Mathf.Clamp(_targetZoom, ZoomMin, ZoomMax);
        }

        // Handle zoom with touch input
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            Vector2 touchMidPoint = (touchZero.position + touchOne.position) / 2f;

            Vector3 worldMidPointBeforeZoom = _camera.ScreenToWorldPoint(new Vector3(touchMidPoint.x, touchMidPoint.y, _camera.nearClipPlane));

            _targetZoom += deltaMagnitudeDiff * OrthoZoomSpeed;
            _targetZoom = Mathf.Clamp(_targetZoom, ZoomMin, ZoomMax);

            Vector3 worldMidPointAfterZoom = _camera.ScreenToWorldPoint(new Vector3(touchMidPoint.x, touchMidPoint.y, _camera.nearClipPlane));
            Vector3 worldDifference = worldMidPointBeforeZoom - worldMidPointAfterZoom;
            _camera.transform.position += worldDifference;
        }

        // Smoothly interpolate the orthographic size
        _camera.orthographicSize = Mathf.SmoothDamp(_camera.orthographicSize, _targetZoom, ref _zoomVelocity, ZoomDampTime, Mathf.Infinity, Time.deltaTime);
    }

    private void ClampCameraPosition()
    {
        Vector3 position = _camera.transform.position;
        position.x = Mathf.Clamp(position.x, -DragMaxX, DragMaxX);
        position.z = Mathf.Clamp(position.z, -DragMaxZ, DragMaxZ);
        _camera.transform.position = position;
    }

    private void ClampCameraZoom()
    {
        _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, ZoomMin, ZoomMax);
    }
}
