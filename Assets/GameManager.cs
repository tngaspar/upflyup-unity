using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float normalGameSpeed = 1f;

    public GameObject wonGameUI;
    public GameObject pauseButton;
    public GameObject restartButton;


    private void Start() 
    { 
    
        Time.timeScale = normalGameSpeed;
    }



    public void WonGame()
    {
        wonGameUI.SetActive(true);
        pauseButton.SetActive(false);
        restartButton.SetActive(false);
    }

    

}
