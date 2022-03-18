using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paper : MonoBehaviour, Interactable
{
    public Dialogue dialogue;
    public GameObject LetterWrapper;
    public GameObject Player;
    public CharacterInputController characterController;
    public InventoryManager characterInventory;
    public DialogueManager dialogueManager;
    public bool requireItem = false;
    public AudioSource aud;


    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        characterController = Player.GetComponent<CharacterInputController>();
       
    }


    void Start()
    {
        dialogueManager = GameObject.FindGameObjectWithTag("ConversationPanel").GetComponent<DialogueManager>();
        characterInventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();

        if (PlayerPrefs.HasKey("LetterRead"))
        {
            if (PlayerPrefs.HasKey("LetterBurned"))
            {
                gameObject.SetActive(false);
            }

            var result = characterInventory.items.Find(o => o.itemName == "Paper");
            if (result != null)
            {
                gameObject.SetActive(false);
            }
        }
    }



    public void Interact()
    {
        aud = GetComponent<AudioSource>();
        if(LetterWrapper.activeSelf != true) {
            aud.Play();
        LetterWrapper.SetActive(true);
        characterController.isInteracting = true;
        }
        else
        {
            characterInventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();

            LetterWrapper.SetActive(false);
            characterController.isInteracting = false;
            var result = characterInventory.items.Find(o => o.prefab == gameObject);
            if(result == null) { 
            characterInventory.items.Add(new Items { prefab = gameObject, icon = GetComponent<SpriteRenderer>().sprite, requireItem = requireItem,itemName = "Paper" });
            }
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(0).transform.gameObject.SetActive(false);
            characterInventory.RefreshSlots();
            dialogueManager.StartDialogue(dialogue);


        }
        PlayerPrefs.SetInt("LetterRead", 1);
    }
}
