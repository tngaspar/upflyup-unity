﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkpoint : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite newSprite2;
    public float secondsAnimationCycle;

    public void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && transform.gameObject.CompareTag("CheckpointNull"))
        {
            activateCheckpoint();

            //play checkpoint sound
            FindObjectOfType<AudioManager>().Play("Checkpoint");

            if (transform.position.y >= other.GetComponent<Player>().highestCheckpointY)
            {
                other.GetComponent<Player>().highestCheckpointY = transform.position.y;
            }

            //reset lives
            GameObject.FindObjectOfType<ButtonRestart>().ResetLives();
            
        }
    }

    public void activateCheckpoint()
    {
        //spriteRenderer.sprite = newSprite;
        transform.gameObject.tag = "Checkpoint";
        InvokeRepeating("checkpointAnim", 0f, secondsAnimationCycle);
    }

    public void checkpointAnim()
    {
        if(spriteRenderer.sprite == newSprite)
        {
            spriteRenderer.sprite = newSprite2;
        }
        else
        {
            spriteRenderer.sprite = newSprite;
        }
    }

}
