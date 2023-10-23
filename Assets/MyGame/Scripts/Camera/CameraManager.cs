using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{

    public Vector2 _delta;

    public bool _isMoving;

    [SerializeField] float _MovementSpeed = 10.0f;

    public void OnLook(InputAction.CallbackContext context)
    {
        _delta = context.ReadValue<Vector2>();  
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _isMoving = context.started || context.performed;
    }

    private void LateUpdate()
    {
        if (_isMoving)
        {
            var position = transform.right * (_delta.x * -_MovementSpeed);
            position += transform.up * (_delta.y * -_MovementSpeed);
            transform.position += position * Time.deltaTime;
        }

    }
}
