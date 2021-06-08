using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerControl>().moves == 2)
            {
                collision.gameObject.GetComponent<PlayerControl>().moves = 1;
            }
        }
    }
}
