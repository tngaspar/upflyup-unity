using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool loadingActive = true;

    public float highestCheckpointY;

    private void Start()
    {
        if (loadingActive == true)
        {
            LoadPlayer();
        }
        InvokeRepeating("SavePlayer", 1f, 1f);
    }


    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        //Loading number of moves availavle
        GetComponent<PlayerControl>().moves = data.moves;

        //Load active checkpoints
        highestCheckpointY = data.highestCheckpointY;
        LoadCheckpoints(data.highestCheckpointY);

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
