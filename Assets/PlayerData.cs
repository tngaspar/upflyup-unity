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
    
    //persistent character unlock thingy
    public bool[] charUnlock; //0-3 for each of the unlockable chars
    public int charActive; //defaults to 0 = initial char

    public PlayerData (Player player, bool reset = false, bool onlychar=false)
    {
        position = new float[3];
        rotation = new float[3];
        velocity = new float[2];

        charUnlock = new bool[4];
        
        if (reset == false & onlychar==false)
        {
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

            //test
            charUnlock[0] = true;
            charUnlock[1] = true;
        }
        else if(reset == true & onlychar ==false)
        {
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

            //test
            charUnlock[0] = false;
            charUnlock[1] = false;
        }
        else if(onlychar == true)
        {
            charUnlock = player.GetComponent<Player>().charsUnlocked;
            charActive = player.GetComponent<Player>().charActive;
        }

    }

}
