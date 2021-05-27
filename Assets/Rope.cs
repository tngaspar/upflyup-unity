using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject prefabRopeSeg;
    public GameObject prefabRopeEnd;
    public int numLinks = 5;

    private void Start()
    {
        hook.tag = "RopeHook";
        GenerateRope();
        //StartCoroutine(TriggerFalse()); //if i want 
    }

    void GenerateRope()
    {
        Rigidbody2D prevBod = hook;
        for (int i = 0; i < numLinks; i++)
        {
            GameObject newSeg = Instantiate(prefabRopeSeg);
            newSeg.tag = "RopeSegment";
            newSeg.transform.parent = transform;
            newSeg.transform.position = transform.position;
            HingeJoint2D hj = newSeg.GetComponent<HingeJoint2D>();
            hj.connectedBody = prevBod;

            prevBod = newSeg.GetComponent<Rigidbody2D>();

        }

        GameObject newSeg2 = Instantiate(prefabRopeEnd);
        newSeg2.tag = "RopeEnd";
        newSeg2.transform.parent = transform;
        newSeg2.transform.position = transform.position;
        HingeJoint2D hj2 = newSeg2.GetComponent<HingeJoint2D>();
        hj2.connectedBody = prevBod;

        prevBod = newSeg2.GetComponent<Rigidbody2D>();
    }

    IEnumerator TriggerFalse()
    {
        yield return new WaitForSeconds(2);

        foreach(Transform child in hook.transform.parent)
        {
            if (child.CompareTag("RopeSegment"))
            {
                child.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }
    }



}
