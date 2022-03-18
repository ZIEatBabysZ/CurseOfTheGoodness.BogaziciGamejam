using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour, Interactable
{


    private void Awake()
    {
        if (PlayerPrefs.HasKey("LetterBurned"))
        {
            gameObject.tag = "Interactable";
        }
                
    }



    public void Interact()
    {
        SceneManager.LoadScene("DreamScene");
    }
}
