using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && transform.gameObject.CompareTag("CheckpointNull"))
        {
            activateCheckpoint();
            if (transform.position.y >= other.GetComponent<Player>().highestCheckpointY)
            {
                other.GetComponent<Player>().highestCheckpointY = transform.position.y;
            }


        }
    }

    public void activateCheckpoint()
    {
        spriteRenderer.sprite = newSprite;
        transform.gameObject.tag = "Checkpoint";
    }


}
