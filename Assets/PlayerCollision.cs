using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public AudioManager audioManager;

    private void OnCollisionEnter2D(Collision2D collision) { 
    
        float volume = Mathf.Clamp01(collision.relativeVelocity.magnitude / 20)*.6f;

        if (collision.gameObject.CompareTag("Terrain"))
            audioManager.Play("TerrainCollision", volume);
        else if (collision.gameObject.CompareTag("Walls"))
            audioManager.Play("WallsCollision", volume);
        else if (collision.gameObject.CompareTag("FallingPlatform"))
            audioManager.Play("ConcreteCollision", volume);
        else if (collision.gameObject.CompareTag("Bouncy"))
            audioManager.Play("Bouncy", volume);
    }
}
