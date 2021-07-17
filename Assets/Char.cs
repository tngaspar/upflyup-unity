using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Char : MonoBehaviour
{
    GameObject charclass;
    Color col;
    private int charnum;
    private bool isUnlocked;

   public void OnEnable()
    {
        charclass = GameObject.Find("CharManager");

        int.TryParse(gameObject.transform.name.Substring(4, 1), out charnum);

        col = GetComponent<Image>().color;
        //if is the current active

        if (charclass.GetComponent<CharClass>().charActive == charnum)
        {
            Debug.Log(charnum);
            col.a = 1;
            GetComponent<Image>().color = col;
        }

        // if not unlocked
        if (charnum > 0)
        {
            isUnlocked = charclass.GetComponent<CharClass>().charsUnlocked[charnum - 1];
            if (isUnlocked == false)
            {
                col.r = 0;
                col.g = 0;
                col.b = 0;
                GetComponent<Image>().color = col;
                GetComponent<Button>().interactable = false;
            }
            else
            {
                col.r = 1;
                col.g = 1;
                col.b = 1;
                GetComponent<Image>().color = col;
                GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            isUnlocked = true;
        }
    }

    public void SetAlpha(float alpha)
    {
        // this funtion also saves the current player selected
        if(isUnlocked == true)
        {
            col.a = alpha;
            GetComponent<Image>().color = col;
            if (alpha == 1)
            {
                charclass.GetComponent<CharClass>().SaveChar(charnum);
            }
            //mising load and initial val just set alpha on onenable
        }
        
    }

}