using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRestart : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    private GameObject[] checkpoints;
    private Transform maxy;
    public Image restartButtonImage;
    private float alpha = 20f;

    public GameObject trail;


    //avoids unwanted long trail in begining of scene load
    public void Start()
    {
        trail.GetComponent<TrailRenderer>().Clear();
    }


    public void Update()
    {
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        if (checkpoints.Length != 0)
        {
            maxy = getHighestCheckpoint(checkpoints);
            if (player.transform.position.y < maxy.transform.position.y)
            {
                alpha = 1f;
            }
            else
            {
                alpha = .2f;
            }
            restartButtonImage.color = new Color(restartButtonImage.color.r, restartButtonImage.color.g, restartButtonImage.color.b, alpha);
        }
    }


    public void ButtonClick()
    {
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        if (checkpoints.Length != 0)
        {
            player.GetComponent<PlayerControl>().DragRelease();

            //choosing the highest active checkpoint
            maxy = getHighestCheckpoint(checkpoints);

            //setting player position to selected checkpoint
            if (player.transform.position.y < maxy.transform.position.y)
            {
                //disable trail for movement
                trail.GetComponent<TrailRenderer>().Clear();
                trail.SetActive(false);

                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                player.GetComponent<Rigidbody2D>().angularVelocity = 0f;
                player.GetComponent<Rigidbody2D>().rotation = 0f;
                player.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                player.GetComponent<Transform>().position = maxy.transform.position;

                //enable trail again
                trail.SetActive(true);

            }
        }
    }

    public Transform getHighestCheckpoint(GameObject[] checkpointsObj) 
    {
        Transform maxy = checkpoints[0].transform;
        foreach (GameObject checkpoint in checkpointsObj)
        {
            if (maxy.position.y < checkpoint.transform.position.y)
            {
                maxy = checkpoint.transform;
            }
        }
        return maxy;

    }

}

