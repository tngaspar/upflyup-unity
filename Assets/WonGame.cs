using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WonGame : MonoBehaviour
{
    public void BackToMenu()
    {
        //won and get back to menu and reset
        SceneManager.LoadScene(0);
        SaveSystem.DeleteFile();
    }
}
