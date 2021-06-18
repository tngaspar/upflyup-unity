using UnityEngine;
using UnityEngine.UI;
using System;


public class TimePlayed : MonoBehaviour
{
    public Text timeText;
    public int seconds;

    private void Start()
    {
        //load in player
        InvokeRepeating("UpdateTimer", 1f, 1f);
    }

    private void UpdateTimer()
    {
        // add conditioning for pause menu when added

        seconds += 1;

        int hours = (int)TimeSpan.FromSeconds(seconds).TotalHours;
        int minutes = TimeSpan.FromSeconds(seconds).Minutes;
        int secs = TimeSpan.FromSeconds(seconds).Seconds;


        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, secs);
        //Debug.Log(seconds);
    }
}
