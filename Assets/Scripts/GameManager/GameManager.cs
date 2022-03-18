using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float maxCameraY;
    public float minCameraY;
    public float maxCameraX;
    public float minCameraX;


    public GameObject pauseMenu;
    public GameObject MainMenuObject;
    public GameObject SettingsObject;
    public AudioMixer audioMixer;
    



    private void Start()
    {
        Application.targetFrameRate = 144;
    }



    public void ShowSettings()
    {
        MainMenuObject.SetActive(false);
        SettingsObject.SetActive(true);
    }


    public void ShowMainMenu()
    {
        MainMenuObject.SetActive(true);
        SettingsObject.SetActive(false);
    }



    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }



    public void TogglePause()
    {
        if(pauseMenu.activeSelf == true)
        {
            pauseMenu.SetActive(false);
            

        }
        else
        {
            pauseMenu.SetActive(true);
            

        }

    }



    

}
