using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject emptyPlayer;
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
        //SaveSystem.DeleteFile(); //deprecated
        emptyPlayer.GetComponent<Player>().ResetPlayer();
    }

    public void DeleteGameSave()
    {
        SaveSystem.DeleteFile();
    }

}
