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


    public PlayerData (Player player)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        rotation = new float[3];
        rotation[0] = player.transform.eulerAngles.x;
        rotation[1] = player.transform.eulerAngles.y;
        rotation[2] = player.transform.eulerAngles.z;

        velocity = new float[2];
        velocity[0] = player.GetComponent<Rigidbody2D>().velocity.x;
        velocity[1] = player.GetComponent<Rigidbody2D>().velocity.y;

        moves = player.GetComponent<PlayerControl>().moves;

        highestCheckpointY = player.highestCheckpointY;

        seconds = player.GetComponent<Player>().seconds;

    }

}
