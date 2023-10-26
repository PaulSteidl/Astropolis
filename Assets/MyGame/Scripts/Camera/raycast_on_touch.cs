﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast_on_touch : MonoBehaviour
{
    public LayerMask obstaclemask;
    public GameObject Test;

    float TouchTime;

    private void Update()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            TouchTime = Time.time;
        }

        if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            if (Time.time - TouchTime <= 0.2)
            {
                if (Input.touchCount == 1)
                {
                    var position = GetPosition();
                    if (position != null)
                    {
                        Instantiate(Test, position.Value, new Quaternion());
                    }
                }
            }
            else
            {
                // this is a long press or drag​
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