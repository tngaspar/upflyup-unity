using System;
using UnityEngine;
using UnityEngine.UI;

public class MaxScore : MonoBehaviour
{
    public Text currentScoreText;
    public Text maxScoreText;

    void Start()
    {
        maxScoreText.text = "0";
    }


    void Update()
    {
        // scoreText.text = (player.position.y - playerStartPos).ToString("0");

        if (Convert.ToInt32(currentScoreText.text)> Convert.ToInt32(maxScoreText.text))
        {
            maxScoreText.text = currentScoreText.text;
        }

    }
}
