using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public GameObject NewGame;
    public GameObject Load;
    public GameObject Settings;

    public GameObject SettingsObject;
    public GameObject MainMenuObject;


    public InventoryManager inventoryManager;
    public Slider VolumeSlider;
    public AudioMixer audioMixer;






    private void Start()
    {
       /* if (!PlayerPrefs.HasKey("LastScene"))
        {
            Load.GetComponent<Button>().interactable = false;
        } */


        inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
        if (inventoryManager != null)
        {
            inventoryManager.items.RemoveAll(o => 1 == 1);
        }
    }






   /* public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("LastScene"));
    } */



    public void StartNewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("EP1_Scene");
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
        audioMixer.SetFloat("volume",volume);
    }


    public void CloseGame()
    {
        Application.Quit();
    }




}
