using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharData
{
    public bool[] charsUnlocked;
    public int charActive;
    public int numCompletes;
    public int bestTimeSeconds;

    public CharData (CharClass charclass)
    {
        charsUnlocked = new bool[4];

        charsUnlocked[0] = charclass.charsUnlocked[0];
        charsUnlocked[1] = charclass.charsUnlocked[1];
        charsUnlocked[2] = charclass.charsUnlocked[2];
        charsUnlocked[3] = charclass.charsUnlocked[3];

        charActive = charclass.charActive;
    }

}
