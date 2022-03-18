using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    public void OpenInfoPanel(string infoText)
    {
        if(transform.GetChild(0).gameObject.activeSelf == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("InfoText").GetComponent<Text>().text = infoText;
        }
        else
        {
            GameObject.FindGameObjectWithTag("InfoText").GetComponent<Text>().text = infoText;
        }
        Invoke("CloseInfoPanel", 5f);
    }




    public void CloseInfoPanel()
    {
        transform.GetChild(0).gameObject.SetActive(false);    
    
    
    }
}
