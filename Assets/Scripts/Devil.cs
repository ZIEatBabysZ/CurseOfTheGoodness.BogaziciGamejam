using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Devil : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue dialogueNecklace;
    public Dialogue dialogueAlone;
    private DialogueManager dialogueManager;
    public InventoryManager inventoryManager;


    private void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
        dialogueManager = GameObject.FindGameObjectWithTag("ConversationPanel").GetComponent<DialogueManager>();

        Invoke("StartDialogue", 1f);
      
     
    }



    public void StartDialogue()
    {
        if (SceneManager.GetActiveScene().name == "CaveinsideScene")
        {
            var result = inventoryManager.items.Find(o => o.itemName == "Necklace");
            if (result != null)
            {
                dialogueManager.StartDialogue(dialogueNecklace);
            }
            else
            {
                dialogueManager.StartDialogue(dialogueAlone);
            }
        }
        else
        {
            dialogueManager.StartDialogue(dialogue);

        }
    }
}
