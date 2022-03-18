using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour, Interactable
{
    public Dialogue dialogue;
    public DialogueManager dialogueManager;
    public bool requireItem = true;
    public InventoryManager inventoryManager;
    public InGameText inGameText;
    public Items paper;
    public GameObject Fire;
    public bool isCompleted = false;
    public AudioSource aud;


    void Awake()
    {
        inGameText = GameObject.FindGameObjectWithTag("InGameText").GetComponent<InGameText>();
        if (PlayerPrefs.HasKey("LetterBurned"))
        {
            Fire.gameObject.SetActive(true);
            isCompleted = true;
        }


        if(isCompleted == true)
        {
            gameObject.tag = "Untagged";
        }
    }



    private void Start()
    {
        dialogueManager = GameObject.FindGameObjectWithTag("ConversationPanel").GetComponent<DialogueManager>();
    }



    public void Interact()
    {
        if (!PlayerPrefs.HasKey("LetterBurned")) { 
        inventoryManager = null;
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
        if(inventoryManager.items.Count != 0 ) {
     

        var result = inventoryManager.items.Find(o => o.itemName == paper.itemName);

        if(result == null)
        {
            inGameText.ShowErrorText();
        }
        else
        {
           
           PlayerPrefs.SetString("LetterBurned", "true");

                    gameObject.tag = "Untagged";

                Fire.gameObject.SetActive(true);
           inventoryManager.items.Remove(result);
                inventoryManager.RefreshSlots();
                    GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInputController>().interactCollision = null;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInputController>().isInInteractArea = false;
                    dialogueManager.StartDialogue(dialogue);

                
        }

        }
        else
        {
            inGameText.ShowErrorText();
        }

        }

    }




  









}
