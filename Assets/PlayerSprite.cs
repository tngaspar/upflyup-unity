using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite[] sprites;

    GameObject charclass;
    private int charnum;

    private void Start()
    {
        charclass = GameObject.Find("CharManager");
        charnum = charclass.GetComponent<CharClass>().charActive;
        spriteRenderer.sprite = sprites[charnum];

    }

    public void SetSprite(int spritenum)
    {
        spriteRenderer.sprite = sprites[spritenum];
        charclass.GetComponent<CharClass>().charActive = spritenum;
    }


}
