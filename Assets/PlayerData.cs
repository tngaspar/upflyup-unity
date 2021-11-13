using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public float[] rotation;
    public float[] velocity;
    public int moves;
    public float highestCheckpointY;
    public int seconds;
    public int maxscore;
    public int lives;
    public int secondsUntilLife;


    public PlayerData (Player player, bool reset = false)
    {

        if (reset == false)
        {
            position = new float[3];
            rotation = new float[3];
            velocity = new float[2];

            position[0] = player.transform.position.x;
            position[1] = player.transform.position.y;
            position[2] = player.transform.position.z;

            rotation[0] = player.transform.eulerAngles.x;
            rotation[1] = player.transform.eulerAngles.y;
            rotation[2] = player.transform.eulerAngles.z;

            velocity[0] = player.GetComponent<Rigidbody2D>().velocity.x;
            velocity[1] = player.GetComponent<Rigidbody2D>().velocity.y;

            moves = player.GetComponent<PlayerControl>().moves;

            highestCheckpointY = player.highestCheckpointY;

            seconds = player.GetComponent<Player>().seconds;

            maxscore = player.GetComponent<Player>().maxscore;

            lives = player.GetComponent<Player>().lives;

            secondsUntilLife = player.GetComponent<Player>().secondsUntilLife;

        }
        else if(reset == true)
        {
            position = new float[3];
            rotation = new float[3];
            velocity = new float[2];
            
            position[0] = 21f;
            position[1] = .5f;
            position[2] = 0f;

            rotation[0] = 0;
            rotation[1] = 0;
            rotation[2] = 0;

            velocity[0] = 0;
            velocity[1] = 0;
            moves = 0;
            highestCheckpointY = 0f;
            seconds = 0;
            maxscore = 0;
            lives = 5;
            secondsUntilLife = 60;

        }

    }

}
