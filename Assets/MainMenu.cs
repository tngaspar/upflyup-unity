using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [HideInInspector] public int seconds;
    [HideInInspector] public int numComp;
    public Text bestTimeText;
    public Text numCompleted;
    [HideInInspector] public GameObject charclass;
    

    //public GameObject emptyPlayer;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        SaveSystem.DeleteFile(); //deprecated
        //emptyPlayer.GetComponent<Player>().ResetPlayer();
    }

    public void DeleteGameSave()
    {
        SaveSystem.DeleteFile();
    }

    private void Start()
    {
        charclass = GameObject.Find("CharManager");
    }

    private void Update()
    {
        seconds = charclass.GetComponent<CharClass>().bestTimeSeconds;

        int hours = (int)TimeSpan.FromSeconds(seconds).TotalHours;
        int minutes = TimeSpan.FromSeconds(seconds).Minutes;
        int secs = TimeSpan.FromSeconds(seconds).Seconds;

        bestTimeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, secs);

        numComp = charclass.GetComponent<CharClass>().numCompletes;
        numCompleted.text = numComp.ToString();
    }


}
