using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FallPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 originalPos;
    public float respawnSeconds = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPos = gameObject.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("FallingPlatform")) && rb.isKinematic == true)
        {
            //collision.gameObject.GetComponent<PlayerControl>().moves = 0; //refils player energy

            //drops and respawn falling platform
            Invoke("DropPlatform", 0.5f);
            Invoke("ResetPlatform", respawnSeconds);
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
    }

    void ResetPlatform()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.transform.position = originalPos;
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }
}
