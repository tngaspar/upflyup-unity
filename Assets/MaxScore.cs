using UnityEngine;
using UnityEngine.UI;

public class MaxScore : MonoBehaviour
{
    public Text currentScoreText;
    public Text maxScoreText;
    private int cscore;
    private int mscore;

    void Start()
    {
        maxScoreText.text = "0";
    }


    void Update()
    {
        // converting score strings to ints
        int.TryParse(currentScoreText.text, out cscore);
        int.TryParse(maxScoreText.text, out mscore);

        //update maxscore
        if ( cscore > mscore)
        {
            maxScoreText.text = currentScoreText.text;
        }

    }
}
