using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameText : MonoBehaviour
{
    public Transform target;
    public Transform InteractText;
    public Transform ErrorText;
    public CharacterInputController characterController;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInputController>();
    }


    private void Update()
    {
        InteractText.position = new Vector3(target.position.x, target.position.y + 2.2f, target.position.z);
        ErrorText.position = new Vector3(target.position.x, target.position.y + 2.7f, target.position.z);

        if (characterController.isInInteractArea == true)
        {
            InteractText.gameObject.SetActive(true);
        }
        else
        {
            InteractText.gameObject.SetActive(false);
        }
    }




   public void ShowErrorText()
    {
        if(ErrorText.transform.gameObject.activeSelf != true) { 

        ErrorText.gameObject.SetActive(true);

        Invoke("HideErrorText", 2f);

        }


    }


    public void HideErrorText()
    {
        ErrorText.gameObject.SetActive(false);
    }



    public void HideInteractText()
    {
        InteractText.gameObject.SetActive(false);
    }

}
