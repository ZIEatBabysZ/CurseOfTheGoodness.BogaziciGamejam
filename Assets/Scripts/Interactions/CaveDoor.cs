using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveDoor : MonoBehaviour, Interactable
{
    public InventoryManager inventoryManager;
    public InGameText inGameText;
    public float lastXPosition;
    public string SceneName;
    public AudioSource aud;

    private void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
        inGameText = GameObject.FindGameObjectWithTag("InGameText").GetComponent<InGameText>();
    }



    public void Interact()
    {
        var result = inventoryManager.items.Find(o => o.itemName == "Key");

        if(result == null)
        {
            inGameText.ShowErrorText();
        }
        else
        {
            aud = GetComponent<AudioSource>();
            aud.Play();
            PlayerPrefs.SetFloat("lastXPosition", lastXPosition);
            PlayerPrefs.SetString("LastScene", SceneName);
            SceneManager.LoadScene(SceneName);
        }
    }
}
