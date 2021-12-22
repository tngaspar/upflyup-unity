using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharClass : MonoBehaviour
{
    [HideInInspector] public bool[] charsUnlocked;
    [HideInInspector] public int charActive;
    [HideInInspector] public int numCompletes;
    [HideInInspector] public int bestTimeSeconds;

    private void Start()
    {
        charsUnlocked = new bool[4];
        if (SaveSystem2.LoadChar() != null) 
        { 
            LoadChar(); 
        }

    }

    public void SaveChar(int charnum = 99)
    {
        if (charnum != 99)
        {
            charActive = charnum;
        }
        SaveSystem2.SaveChar(this);
    }

    public void LoadChar()
    {
        CharData data = SaveSystem2.LoadChar();
        charsUnlocked = data.charsUnlocked;
        charActive = data.charActive;
        numCompletes = data.numCompletes;
        bestTimeSeconds = data.bestTimeSeconds;
    }

}
