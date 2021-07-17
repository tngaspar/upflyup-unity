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
        Unactivate(charNumber);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            charclass.GetComponent<CharClass>().charsUnlocked[charNumber - 1] = true;
            // become new sprite
            collision.GetComponent<PlayerSprite>().SetSprite(charNumber);
            Unactivate(charNumber);
            charclass.GetComponent<CharClass>().SaveChar(charNumber);
        }
    }

    private void Unactivate(int charnumber)
    {
        if (charclass.GetComponent<CharClass>().charsUnlocked[charnumber - 1] == true)
        {
            gameObject.SetActive(false);
        }
    }
}
