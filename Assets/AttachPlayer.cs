using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    GameObject player;
    PlayerControl playerControl;

    private bool thisRope = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = player.GetComponent<PlayerControl>();

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            player.GetComponent<PlayerControl>().onRope = true;
            thisRope = true;

        }
    }


    void Update()
    {

        if (playerControl.onRope == true && thisRope == true)
        {
            playerControl.moves = 0; //full energy
            player.transform.position = new Vector3(transform.position.x, transform.position.y - .5f, player.transform.position.z); //attach to rope

        }
        else
        {
            thisRope = false;
        }

    }


}
