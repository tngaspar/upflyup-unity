using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockChar : MonoBehaviour
{
    GameObject charclass;
    public int charNumber;
    private void Start()
    {
        charclass = GameObject.Find("CharManager");

        //if unlocked turn off
        if (charclass.GetComponent<CharClass>().charsUnlocked[charNumber - 1] == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            charclass.GetComponent<CharClass>().charsUnlocked[charNumber-1] = true;
            // become new sprite
            collision.GetComponent<PlayerSprite>().SetSprite(charNumber);
        }
    }
}
