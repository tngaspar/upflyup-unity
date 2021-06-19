using UnityEngine;

public class PlayerEnergyTracker : MonoBehaviour
{
    public Color zeroMovesMade;
    public Color oneMoveMade;
    public Color twoMovesMade;

    private void Update()
    {
        int movesMade = GetComponent<PlayerControl>().moves;
        if (movesMade == 0)
        {
            GetComponent<SpriteRenderer>().color = zeroMovesMade;
        }
        else if (movesMade == 1)
        {
            GetComponent<SpriteRenderer>().color = oneMoveMade;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = twoMovesMade;
        }
    }
}
