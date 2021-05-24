using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && transform.gameObject.CompareTag("Untagged"))
        {
            spriteRenderer.sprite = newSprite;
            transform.gameObject.tag = "Checkpoint";
        }
    }


}
