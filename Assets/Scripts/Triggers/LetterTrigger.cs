using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    public DialogueManager dialogueManager;


    private void Start()
    {
        dialogueManager = GameObject.FindGameObjectWithTag("ConversationPanel").GetComponent<DialogueManager>();
        if (PlayerPrefs.HasKey("LetterRead"))
        {
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(dialogue != null) { 
            dialogueManager.StartDialogue(dialogue);
                Destroy(gameObject,0.4f);
            }
        }
    }



}





