using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public int moves;
    public float highestCheckpointY;


    public PlayerData (Player player)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        moves = player.GetComponent<PlayerControl>().moves;

        highestCheckpointY = player.highestCheckpointY;
        Debug.Log(highestCheckpointY);
        

    }

}
