using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour,Interactable
{


    public GameObject ConversationPanel;
    public Dialogue AltDialogue;
    public Items missionItem;
    public Items rewardItem;
    public Items rewardItem2;
    public Dialogue dialogue;
    public Dialogue goodDialogue;
    public Dialogue badDialogue;
    public Dialogue successDialogue;
    public MStatus missionStatus;
    public CharacterInputController player;
    public ChoiceManager choiceManager;
    public bool isGivingMissionItem;
    public bool isEyeChoice;
    public InventoryManager inventoryManager;


    private void Start()
    {
        ConversationPanel = GameObject.FindGameObjectWithTag("ConversationPanel");
        choiceManager = GetComponent<ChoiceManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInputController>();
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
    }


    public enum MStatus
    {
        waiting,
        completed,
        received
    }




  public void Interact()
    {
        if(gameObject.name == "hanci")
        {
            
            var result = inventoryManager.items.Find(o => o.itemName == "Eye");
            if(result != null)
            {
                  ConversationPanel.GetComponent<DialogueManager>().StartDialogue(AltDialogue,choiceManager.choiceModel,false,missionItem,rewardItem,rewardItem2,isEyeChoice);
         
                return;
            }
        }

        if(gameObject.name == "koylukadin")
        {
            var result = inventoryManager.items.Find(o => o.itemName == "Eye");
            if (result != null)
            {
                ConversationPanel.GetComponent<DialogueManager>().StartDialogue(dialogue, choiceManager.choiceModel,false, missionItem,rewardItem,rewardItem2, isEyeChoice);
        
                return;
            }
        }


         if (PlayerPrefs.HasKey(choiceManager.choiceModel.successChoice))
        {
            ConversationPanel.GetComponent<DialogueManager>().StartDialogue(successDialogue);
        }
        else if (PlayerPrefs.HasKey(choiceManager.choiceModel.goodChoice))
        {
            ConversationPanel.GetComponent<DialogueManager>().StartDialogue(goodDialogue);
        }
        else if (PlayerPrefs.HasKey(choiceManager.choiceModel.badChoice))
        {
            ConversationPanel.GetComponent<DialogueManager>().StartDialogue(badDialogue);
        }
        
        else { 
        ConversationPanel.GetComponent<DialogueManager>().StartDialogue(dialogue,choiceManager.choiceModel,isGivingMissionItem,missionItem,null,null,isEyeChoice);
        }
        player.isInteracting = true;



    }







   
}
