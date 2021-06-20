using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public AudioManager audioManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
            float volume = Mathf.Clamp01(collision.relativeVelocity.magnitude / 20)*.6f;
            audioManager.Play("TerrainCollision", volume);

    }
}
