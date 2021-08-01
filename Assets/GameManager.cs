using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float normalGameSpeed = 1f;

    public GameObject wonGameUI;
    public GameObject pauseButton;
    public GameObject restartButton;
    public GameObject charclass;
    public GameObject player;

    private void Start()
    {
        Time.timeScale = normalGameSpeed;
    }

    public void WonGame()
    {
        countWin();
        wonGameUI.SetActive(true);
        pauseButton.SetActive(false);
        restartButton.SetActive(false);
    }

    private void countWin()
    {
        charclass = GameObject.Find("CharManager");
        charclass.GetComponent<CharClass>().numCompletes += 1;
        charclass.GetComponent<CharClass>().bestTimeSeconds = player.GetComponent<Player>().seconds;
        charclass.GetComponent<CharClass>().SaveChar();
    }

}
