using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    private Text ConversationText;
    public bool isTalking = false;
    public GameObject choiceDialogue;
    public CharacterInfo playerInfo;
    public CharacterInputController player;
    public Dialogue currentDialogue;
    public ChoiceModel currentChoice;
    public GameObject InfoWrapper;
    public InfoPanel infoPanel;
    public bool missionItemAfterDialogue;
    public InventoryManager inventoryManager;
    public Items item;
    public Items item2;
    public Items rewardItem;
    public Items rewardItem2;
    public bool isEye;
    public Animator TransitionAnim;
    private void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInfo>();
        choiceDialogue = GameObject.FindGameObjectWithTag("ChoiceDialogue");
        InfoWrapper = GameObject.FindGameObjectWithTag("InfoWrapper");
        infoPanel = InfoWrapper.GetComponent<InfoPanel>();
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
        TransitionAnim = GameObject.FindGameObjectWithTag("TransitionPanel").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInputController>();

        sentences = new Queue<string>();



    }

    public void StartDialogue(Dialogue dialogue,ChoiceModel choice = null,bool isGivingMissionItem = false,Items missionItem = null,Items rItem = null,Items rItem2 = null,bool isEyeChoice = false)
    {
        isEye = isEyeChoice;
        currentChoice = choice;
        currentDialogue = dialogue;
        missionItemAfterDialogue = isGivingMissionItem;
        item = missionItem;
        item2 = rItem;
        rewardItem = rItem;
        rewardItem2 = rItem2;
        isTalking = true;
        player.isInteracting = true;
        player.anim.SetFloat("XValue", 0);
        transform.GetChild(0).gameObject.SetActive(true);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        GameObject.FindGameObjectWithTag("ConversationName").GetComponent<Text>().text = dialogue.name;
        ConversationText = GameObject.FindGameObjectWithTag("ConversationText").GetComponent<Text>();
        DisplayNextSentence();



    }



    public void DisplayNextSentence()
    {
     
        if (sentences.Count == 0)
        {
            isTalking = false;
            EndDialogue();
            if (currentDialogue.choice == true)
            {
                ShowChoiceDialogue();
            }
            return;
        }

        string sentence = sentences.Dequeue();
        ConversationText.text = sentence;
      //  StartCoroutine(TypeSentence(sentence));
    }

   /* IEnumerator TypeSentence(string sentence)
    {
        ConversationText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            ConversationText.text += letter;
            yield return null;
        }
    } */


    void EndDialogue()
    {
        if(missionItemAfterDialogue == true && (item != null || item2 != null ) )
        {
            var result = inventoryManager.items.Find(o => o == item);
            if(result == null)
            {
                inventoryManager.items.Add(item);
                inventoryManager.RefreshSlots();
                infoPanel.OpenInfoPanel(item.itemName + " eklendi!");
            }
        }
        transform.GetChild(0).gameObject.SetActive(false);
        player.isInteracting = false;
        if(SceneManager.GetActiveScene().name == "DreamScene")
        {
            TransitionAnim.SetBool("isLoading", true);
            Invoke("LoadLevel", 1.3f);
           
        }else if(SceneManager.GetActiveScene().name == "CaveinsideScene")
        {
            TransitionAnim.SetBool("isLoading", true);
            Invoke("LoadCredits", 1.3f);
        }
    }


    public void LoadCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }



    void LoadLevel()
    {
        SceneManager.LoadScene("EP2_Scene");
    }



    void ShowChoiceDialogue()
    {
        if(currentChoice != null)
        {
            player.isInteracting = true;
            choiceDialogue.transform.GetChild(0).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("ChoiceTitle").GetComponent<Text>().text = currentChoice.title;
            GameObject.FindGameObjectWithTag("ChoiceContent").GetComponent<Text>().text = currentChoice.content;
        }
    }



    public void AcceptChoice()
    {
        if (isEye == true)
        {
            var result = inventoryManager.items.Find(o => o.itemName == "Eye");
            if(result != null)
            {
                inventoryManager.items.Remove(result);
                infoPanel.OpenInfoPanel("Göz envanterden silindi !");
            }
            if (rewardItem != null)
            {
                inventoryManager.items.Add(rewardItem);
                infoPanel.OpenInfoPanel(rewardItem.itemName+ " " + " eklendi !");
            }
            if (rewardItem2 != null)
            {
                inventoryManager.items.Add(rewardItem2);
                infoPanel.OpenInfoPanel(rewardItem2.itemName+ " " + " eklendi !");
            }
            inventoryManager.RefreshSlots();
        }
        playerInfo.currentCurse= playerInfo.currentCurse + 35f;
        if(currentChoice.infoText != null) {
            infoPanel.OpenInfoPanel(currentChoice.infoText);
            PlayerPrefs.SetString(currentChoice.goodChoice, "true");
            
        }
        CloseChoiceDialogue();
    }




    public void DeclineChoice()
    {
        PlayerPrefs.SetString(currentChoice.badChoice, "true");
        CloseChoiceDialogue();
    }

    public void CloseChoiceDialogue()
    {
        choiceDialogue.transform.GetChild(0).gameObject.SetActive(false);
        currentChoice = null;
        currentDialogue = null;
        player.isInteracting = false;
    }



}
