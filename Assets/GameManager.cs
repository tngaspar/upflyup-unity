using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject wonGameUI;

    public void WonGame()
    {
        wonGameUI.SetActive(true);
    }
}
