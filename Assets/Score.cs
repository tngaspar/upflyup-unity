using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    private float playerHeight;
    private const float baseHeight = 1.25f;

    void Update()
    {
        // scoreText.text = (player.position.y - playerStartPos).ToString("0");
        playerHeight = player.position.y - baseHeight;
        scoreText.text = playerHeight.ToString("0");

    }
}
