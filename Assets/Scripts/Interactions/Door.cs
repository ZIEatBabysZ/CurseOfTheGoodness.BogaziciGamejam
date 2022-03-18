using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour , Interactable
{
    public string SceneName;
    public float lastXPosition;
    private GameObject TransitionPanel;
    public bool requireItem = false;
    public AudioSource aud;




    public void Interact()
    {
        aud = GetComponent<AudioSource>();
        PlayerPrefs.SetString("LastScene", SceneName);
        PlayerPrefs.SetFloat("lastXPosition", lastXPosition);
        TransitionPanel = GameObject.FindGameObjectWithTag("TransitionPanel");
        aud.Play();
        if(TransitionPanel != null) { 
        TransitionPanel.GetComponent<Animator>().SetBool("isLoading", true);
        Invoke("LoadLevel", 1.3f);

        }

    }




    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneName);

    }

}
