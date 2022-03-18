using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DialogueCreater 
{


    public class DialogueFactory
    {
        public  DialogueManager dialogueManager;
        private void Start()
        {
            dialogueManager = GameObject.FindGameObjectWithTag("ConversationPanel").GetComponent<DialogueManager>();
        }

        public void SendDialogue(Dialogue dialogue)
        {
            dialogueManager.StartDialogue(dialogue);
        }

    }
   




    

}
