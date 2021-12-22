using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool loadingActive = true;

    [HideInInspector] public float highestCheckpointY;

    public Rigidbody2D rb;

    [HideInInspector]public int seconds;
    public Text timerText;

    [HideInInspector] public int maxscore;
    public Text maxScoreText;

    [HideInInspector] public int lives;
    [HideInInspector] public int secondsUntilLife;
    public Button restartbutton;

    private void Start()
    {

        if (loadingActive == true && SaveSystem.LoadPlayer() != null)
        {
            LoadPlayer();
        }
        else
        {
            restartbutton.GetComponent<ButtonRestart>().lives = 5;
        }
        InvokeRepeating("SavePlayer", 1f, 1f);
    }


    public void SavePlayer()
    {
        // updating timer
        seconds = timerText.GetComponent<TimePlayed>().seconds;
        maxscore = maxScoreText.GetComponent<MaxScore>().mscore;
        lives = restartbutton.GetComponent<ButtonRestart>().lives;
        secondsUntilLife = restartbutton.GetComponent<ButtonRestart>().secondsUntilLife;
        SaveSystem.SavePlayer(this);

    }

    public void ResetPlayer()
    {
        // call this function to reset the game like the old reset file
        seconds = 0;
        lives = 5;
        SaveSystem.SavePlayer(this, true);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        Vector3 rotation;
        rotation.x = data.rotation[0];
        rotation.y = data.rotation[1];
        rotation.z = data.rotation[2];
        transform.eulerAngles = rotation;

        //velocity
        Vector2 velocity;
        velocity.x = data.velocity[0];
        velocity.y = data.velocity[1];
        rb.velocity = velocity;

        //Loading number of moves availavle
        GetComponent<PlayerControl>().moves = data.moves;

        //Load active checkpoints
        highestCheckpointY = data.highestCheckpointY;
        LoadCheckpoints(data.highestCheckpointY);

        //Load timer
        seconds = data.seconds;
        timerText.GetComponent<TimePlayed>().seconds = seconds;

        //Load maxScore
        maxscore = data.maxscore;
        maxScoreText.GetComponent<MaxScore>().mscore = maxscore;

        //Load amoutn of lifes
        lives = data.lives;
        restartbutton.GetComponent<ButtonRestart>().lives = lives;

        //load seconds until new live
        secondsUntilLife = data.secondsUntilLife;
        restartbutton.GetComponent<ButtonRestart>().secondsUntilLife = secondsUntilLife;
    }


    private void LoadCheckpoints(float highestY)
    {
        foreach(GameObject flag in GameObject.FindGameObjectsWithTag("CheckpointNull"))
        {
            if (flag.transform.position.y <= highestY)
            {
                flag.GetComponent<checkpoint>().activateCheckpoint();
            }
        }
    }

}
