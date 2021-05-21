using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    private float playerStartPos;

    private void Start()
    {
        playerStartPos = player.position.y;
    }

    void Update()
    {
        scoreText.text = (player.position.y - playerStartPos).ToString("0");
    }
}
