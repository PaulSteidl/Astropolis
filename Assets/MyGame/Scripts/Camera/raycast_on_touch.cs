using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast_on_touch : MonoBehaviour
{
    public LayerMask obstaclemask;

    float TouchStartTime;

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                TouchStartTime = Time.time;
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                if (Time.time - TouchStartTime <= 0.1)
                {
                    var position = GetPosition();
                    if (position != null)
                    {
                        // Do something with the position if needed
                        Debug.Log("Position: " + position);
                    }
                }
                else
                {
                    // This is a long press or drag
                }
            }
        }
    }

    private Vector3? GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        RaycastHit[] hits = new RaycastHit[1];
        if (Physics.RaycastNonAlloc(ray, hits)>0)
        {
            return hits[0].point;
        }
        return null;
    }
}
