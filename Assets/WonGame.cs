using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WonGame : MonoBehaviour
{
    GameObject charclass;
    private int charNumber = 4; //last sprite number

    private void Start()
    {
        charclass = GameObject.Find("CharManager");
    }


    public void BackToMenu()
    {
        //unlock last char if not unlocked and save it if its first time
        if(charclass.GetComponent<CharClass>().charsUnlocked[charNumber - 1] == false)
        {
            charclass.GetComponent<CharClass>().charsUnlocked[charNumber - 1] = true;
            charclass.GetComponent<CharClass>().SaveChar(charNumber);
        }

        //won and get back to menu and reset
        SceneManager.LoadScene(0);
        SaveSystem.DeleteFile();
    }
}
