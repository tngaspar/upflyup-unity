using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdMenu : MonoBehaviour
{
    public GameObject adMenu;
    public GameManager gameManager;

    public Button pauseButton;
    public Button restartButton;

    public void ActivateAdMenu()
    {
        adMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseButton.interactable = false;
        restartButton.interactable = false;
    }

    public void DeactivateAdMenu()
    {
        adMenu.SetActive(false);
        Time.timeScale = gameManager.normalGameSpeed;
        pauseButton.interactable = true;
        restartButton.interactable = true;
    }
}
