using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameManager gameManager;

    public GameObject player;
    public void PauseButtonClick()
    {
        if (!GameIsPaused)
        {
            Pause();
        }
        player.GetComponent<PlayerControl>().DragRelease();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = gameManager.normalGameSpeed;
        GameIsPaused = false;
    }

    public void LoadMenu()
    {
        GameIsPaused = false;
        Time.timeScale = gameManager.normalGameSpeed;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        GameIsPaused = false;
        Debug.Log("Quitting application");
        Application.Quit();
    }

}
