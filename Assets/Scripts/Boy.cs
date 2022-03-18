using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour, Interactable
{
    private CharacterInfo playerInfo;
    private InfoPanel infoWrapper;



    private void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInfo>();
        infoWrapper = GameObject.FindGameObjectWithTag("InfoWrapper").GetComponent<InfoPanel>();
    }


    public void Interact()
    {
        if (PlayerPrefs.HasKey("boyChoosed")) { 
        if (!PlayerPrefs.HasKey("boyPaid")) { 
        playerInfo.currentCurse = playerInfo.currentCurse + 35f;
        PlayerPrefs.SetString("boyPaid", "true");

        }
        else
        {
            infoWrapper.OpenInfoPanel("Zaten tedavi edildi.");
        }

        }
        else
        {
            infoWrapper.OpenInfoPanel("Yardým etmemeyi seçtin.");
        }
    }
}
