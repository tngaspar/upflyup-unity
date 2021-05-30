using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePlatform : MonoBehaviour
{

    public float speed;
    public Transform thisTransform;
    public Transform A;
    public Transform B;
    private Transform currentTarget;
    private float step;

    private void Start()
    {
        currentTarget.position = B.position;
    }

    private void FixedUpdate()
    {
        step = speed * Time.deltaTime;

        if (thisTransform.position == A.position)
        {
            currentTarget.position = B.position;
        }
        else if (thisTransform.position == B.position)
        {
            currentTarget.position = A.position;
        }

        thisTransform.position = Vector3.MoveTowards(thisTransform.position, currentTarget.position, step);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
