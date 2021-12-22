using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision) { 
    
        float volume = Mathf.Clamp01(collision.relativeVelocity.magnitude / 20)*.6f;

        if (collision.gameObject.CompareTag("Terrain"))
            FindObjectOfType<AudioManager>().Play("TerrainCollision", volume);
        else if (collision.gameObject.CompareTag("Walls"))
            FindObjectOfType<AudioManager>().Play("WallsCollision", volume);
        else if (collision.gameObject.CompareTag("FallingPlatform"))
            FindObjectOfType<AudioManager>().Play("ConcreteCollision", volume);
        else if (collision.gameObject.CompareTag("Bouncy"))
            FindObjectOfType<AudioManager>().Play("Bouncy", volume);
    }
}
