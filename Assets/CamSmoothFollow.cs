﻿using UnityEngine;

public class CamSmoothFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = transform.position = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        transform.position = smoothedPosition;
        if (transform.position.y < 15)
        {
            transform.position = new Vector3(transform.position.x, 15, transform.position.z);
        }

    }
}