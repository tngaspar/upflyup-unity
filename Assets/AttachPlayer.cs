using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttachPlayer : MonoBehaviour
{
    GameObject player;
    PlayerControl playerControl;

    public float offsetY = 0;

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
            Vector3 goal = new Vector3(transform.position.x, transform.position.y + offsetY, player.transform.position.z);//attach to 
            
            float distance = Math.Abs(player.transform.position.y - goal.y);

            if (distance > 0.05)
            {
                player.transform.position = Vector3.Lerp(player.transform.position, goal, 7 * Time.deltaTime/distance);
            }
            else
            {
                player.transform.position = goal;
            }


            
            

            Debug.Log(player.transform.position.y - goal.y);

            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            player.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            player.GetComponent<Rigidbody2D>().rotation = 0f;
            //player.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f)); player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
        else
        {
            thisRope = false;
        }

    }


}
