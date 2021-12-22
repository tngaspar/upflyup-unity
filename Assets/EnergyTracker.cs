using UnityEngine;
using UnityEngine.UI;

public class EnergyTracker : MonoBehaviour
{
    public GameObject player;
    public int energyId = 1;

    private int currentEnergy;

    private void Update()
    {
        currentEnergy = player.GetComponent<PlayerControl>().moves;
        if (currentEnergy >= energyId + 1)
        {
            GetComponent<Image>().color = new Color(1f, 1f, 1f, .2f);
        }
        else
        {
            GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

}
