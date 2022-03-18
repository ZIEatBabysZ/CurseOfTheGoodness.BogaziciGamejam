using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterInfo : MonoBehaviour
{
    public Dialogue dialogue;
    public CharacterInputController character;
    private DialogueManager dialogueManager;
    public int candleCount = 0;
    public Animator TransitionPanel;

    private void Start()
    {
        TransitionPanel = GameObject.FindGameObjectWithTag("TransitionPanel").GetComponent<Animator>();
        dialogueManager = GameObject.FindGameObjectWithTag("ConversationPanel").GetComponent<DialogueManager>();
        character = GetComponent<CharacterInputController>();
        if (!PlayerPrefs.HasKey("LetterRead"))
        {
            if(SceneManager.GetActiveScene().name == "Home")
            {
                dialogueManager.StartDialogue(dialogue);
            }
        }
    }


    public float maxCurse = 100f;
    public float currentCurse { get { return PlayerPrefs.HasKey("CurrentCurse") ? PlayerPrefs.GetFloat("CurrentCurse") : 0; } set { PlayerPrefs.SetFloat("CurrentCurse", value); } }



    private void FixedUpdate()
    {
        if (currentCurse >= maxCurse)
        {
            character.isInteracting = true;
            TransitionPanel.SetBool("isLoading", true);
            Invoke("LoadLevel", 1.3f);
        }
    }




    public void LoadLevel()
    {
        SceneManager.LoadScene("DeathScene");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("koylukadin"))
        {
            collision.GetComponent<NPC>().Interact();
        }
    }


}
