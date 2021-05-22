﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;
    public Rigidbody2D rb;
    public LineRenderer lr;

    Vector3 dragStartPos;
    Touch touch;

    float speed;
    public float speedtoMove = .1f;

    public int numMoves = 2;
    public int moves = 0;
    int stillcount = 0;
    public int framestomove = 10;

    private void Update()
    {
        speed = rb.velocity.magnitude;
        if (Input.touchCount > 0 && moves < numMoves)
        {
            touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }
            if (touch.phase == TouchPhase.Moved && lr.positionCount != 0)
            {
                Dragging();
            }
            if (touch.phase == TouchPhase.Ended && lr.positionCount != 0)
            {
                DragRelease();
                moves += 1; 
            }
        }
        else if (speed < speedtoMove)
        {
            stillcount += 1;
            if (stillcount == framestomove)
            {
                moves = 0;
            }
        }
        else if (speed >= speedtoMove)
        {
            stillcount = 0;
        }
    }

    void DragStart() {
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartPos);
    }
    void Dragging() {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        draggingPos.z = 0f;
        lr.positionCount = 2;
        lr.SetPosition(1, draggingPos);
    }
    void DragRelease() {
        lr.positionCount = 0;

        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        dragReleasePos.z = 0f;
        Vector3 force = dragStartPos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        rb.AddForce(clampedForce, ForceMode2D.Impulse);

    }



}
