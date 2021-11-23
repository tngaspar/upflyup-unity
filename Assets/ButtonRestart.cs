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

    //implement lives:
    public int maxLives = 5;
    public Text livesText;
    [HideInInspector] public int lives=5;
    public Image videoImage;
    public Canvas adCanvas;
    public GameObject adMenu;

    public bool adsOn = false;

    public Text timeleftText;
    public int secondsUntilLife = 60;

    //avoids unwanted long trail in begining of scene load
    public void Start()
    {
        trail.GetComponent<TrailRenderer>().Clear();

        //load lives from save
        livesText.text = lives.ToString();
        timeleftText.text = secondsUntilLife.ToString();

        InvokeRepeating("ResetLivesAfterTime", 1f, 1f);
    }


    public void Update()
    {
        ResetLives();
        //checkpoints
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        if (checkpoints.Length != 0)
        {
            maxy = getHighestCheckpoint(checkpoints);
            if (player.transform.position.y < maxy.transform.position.y & lives !=0)
            {
                alpha = 1f;
            }
            else
            {
                alpha = .2f;
            }
            restartButtonImage.color = new Color(restartButtonImage.color.r, restartButtonImage.color.g, restartButtonImage.color.b, alpha);
        }

        //video image
        if (lives == 0)
        {
            //videoImage.enabled = true;
            livesText.enabled = false;
            timeleftText.enabled = true;
        }
        else
        {
            //videoImage.enabled = false;
            livesText.enabled = true;
            timeleftText.enabled = false;
        }
    }


    public void ResetLivesAfterTime()
    {
        if (secondsUntilLife > 0 & lives < 5)
        {
            secondsUntilLife--;
        }
        else
        {
            IncreaseLives();
            secondsUntilLife = 60;
        }
        timeleftText.text = secondsUntilLife.ToString();
    }

    public void ButtonClick()
    {
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        if (checkpoints.Length != 0)
        {
            player.GetComponent<PlayerControl>().DragRelease();
            //choosing the highest active checkpoint
            maxy = getHighestCheckpoint(checkpoints);
            if (player.transform.position.y < maxy.transform.position.y)
            {
                if (lives != 0)
                {
                    //setting player position to selected checkpoint

                    PlayerToCheckpoint();
                    DecreaseLives();
                }
                else
                {//play ad video here and restock lives // put a submenu here
                    if(adsOn == true)
                    {
                        adCanvas.GetComponent<AdMenu>().ActivateAdMenu();
                    }
                    else
                    {
                       // ResetLives();
                        //PlayerToCheckpoint();
                    }

                    //gameObject.GetComponentInParent<AdMenu>().ActivateAdMenu();
                    //gameObject.GetComponentInParent<AdsManager>().PlayRewardedAd();
                }
            }

            

        }
    }

    public void PlayerToCheckpoint()
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


    public void DecreaseLives()
    {
        if (lives > 0)
        {
            lives -= 1;
            livesText.text = lives.ToString();
        }
    }

    public void IncreaseLives()
    {
        if (lives < maxLives)
        {
            lives += 1;
            livesText.text = lives.ToString();
        }
    }

    public void ResetLives()
    {
        lives = maxLives;
        livesText.text = lives.ToString();
    }

}

