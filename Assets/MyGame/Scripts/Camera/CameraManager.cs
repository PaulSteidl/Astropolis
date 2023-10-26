using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
	GameObject self;
	public double TimeOnScreen;
	public float orthoZoomSpeed;
	public float z_maxdrag;
	public float x_maxdrag;

	public Vector2 _delta;

    public bool _isMoving;

    [SerializeField] float _MovementSpeed = 10.0f;


    private void Start()
    {
		self = gameObject;
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



		float a = self.transform.localPosition.z;
		float b = self.transform.localPosition.x;
		float c = self.transform.localPosition.y;

		if (_isMoving)
		{
				var position = transform.right * (_delta.x * -_MovementSpeed * (GetComponent<Camera>().orthographicSize / 60));
				position += transform.up * (_delta.y * -_MovementSpeed * (GetComponent<Camera>().orthographicSize / 60));
				transform.position += position * Time.deltaTime;
		}

        if (gameObject.transform.position.x <= -x_maxdrag)
        {
			self.transform.position = new Vector3(-x_maxdrag + 0.001f, c, a);
		}
		if (gameObject.transform.position.x >= x_maxdrag)
		{
			self.transform.position = new Vector3(x_maxdrag - 0.001f, c, a);
		}
		if (gameObject.transform.position.z >= z_maxdrag)
		{			
			self.transform.position = new Vector3(b, c, z_maxdrag - 0.001f);
		}
		if (gameObject.transform.position.z <= -z_maxdrag)
		{
			self.transform.position = new Vector3(b, c, -z_maxdrag + 0.001f);
		}

		// If there are two touches on the device...
		if (Input.touchCount == 2)
		{
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			// If the camera is orthographic...
			if (GetComponent<Camera>().orthographic)
			{
				// ... change the orthographic size based on the change in distance between the touches.
				GetComponent<Camera>().orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

				// Make sure the orthographic size never drops below zero.
				GetComponent<Camera>().orthographicSize = Mathf.Max(GetComponent<Camera>().orthographicSize, 0.1f);
			}
		}
	}
}
