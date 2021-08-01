using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WonGame : MonoBehaviour
{
    GameObject charclass;
    private int charNumber = 4; //last sprite number

    public GameObject player;

    private void Start()
    {
        charclass = GameObject.Find("CharManager");
    }


    public void BackToMenu()
    {
        //update save of numcompletes and best time
        countWin();

        //unlock last char if not unlocked and save it if its first time
        if (charclass.GetComponent<CharClass>().charsUnlocked[charNumber - 1] == false)
        {
            charclass.GetComponent<CharClass>().charsUnlocked[charNumber - 1] = true;
            charclass.GetComponent<CharClass>().SaveChar(charNumber);
        }


        //won and get back to menu and reset
        SceneManager.LoadScene(0);
        SaveSystem.DeleteFile();
    }

    
    public void countWin()
    {
        charclass.GetComponent<CharClass>().numCompletes += 1;
        charclass.GetComponent<CharClass>().bestTimeSeconds = player.GetComponent<Player>().seconds;
        charclass.GetComponent<CharClass>().SaveChar();
    }
}
