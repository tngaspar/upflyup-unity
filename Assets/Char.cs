using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Char : MonoBehaviour
{
    private GameObject emptyPlayer;

    Color col;

    private void Start()
    {
        emptyPlayer = GameObject.Find("emptyPlayer");
        col = GetComponent<Image>().color;

        // if not unlocked
        if (emptyPlayer.GetComponent<Player>().charsUnlocked[3] == false)
        {
            Debug.Log("yo");
            col.r = 0;
            col.g = 0;
            col.b = 0;
            GetComponent<Image>().color = col;
        }
    }

    public void SetAlpha(float alpha)
    {
        
        col.a = alpha;
        GetComponent<Image>().color = col;
    }

}