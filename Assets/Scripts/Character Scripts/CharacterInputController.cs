using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using static SettingsModel;





    public class CharacterInputController : MonoBehaviour
    {

        [Header("References")]
        public Vector2 input_movement;
        private CharacterMovement movementInput;
    public GameManager gameManager;
        private RaycastHit groundControlHit;
        public bool isGrounded;
        private Rigidbody2D rigid;
        public bool isInInteractArea = false;
        public bool jump = false;
        public LayerMask groundMask;
        public Collider2D interactCollision;
        public Animator anim;
         public bool isInteracting = false;
    public InventoryManager inventoryManager;
    public DialogueManager dialogueManager;


        [Header("Settings")]
        public PlayerSettingsModel playerSettings;



        private void Awake()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
        dialogueManager = GameObject.FindGameObjectWithTag("ConversationPanel").GetComponent<DialogueManager>();
        PlayerPositionCheck();
        inventoryManager.RefreshSlots();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        movementInput = new CharacterMovement();
        movementInput.CharacterControls.Movement.performed += e => input_movement = e.ReadValue<Vector2>();
        movementInput.CharacterControls.Jump.performed += e => Jump();
        movementInput.CharacterControls.Pause.performed += e => TogglePause();
        movementInput.CharacterControls.Interaction.performed += e => DoInteract();
        movementInput.Enable();

    }

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        groundControl();

        if(isInteracting == false) { 
        SetMovementAnim();
        FlipSprite();
        }
    }


    private void FixedUpdate()
    {
        Move();
    }

    public void TogglePause()
    {
        gameManager.TogglePause();
    }


    void Move()
    {
        if(isInteracting == false) { 
        gameObject.transform.position += new Vector3(input_movement.x,0,0) * Time.fixedDeltaTime * playerSettings.movementSpeed;
        }
    }


    void Jump()
    {

        if (rigid != null) {  


        if (isGrounded) { 
        rigid.AddForce(new Vector2(0, playerSettings.jumpForce), ForceMode2D.Impulse);
        }



        }

    }








    void groundControl()

    {
        Vector2 rayCenter = new Vector2(transform.position.x, transform.position.y - 0.4f);
        RaycastHit2D hit = Physics2D.Raycast(rayCenter, new Vector2(0, -1), playerSettings.groundCheckDistance, groundMask);
        if(hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        } 

    }


    void FlipSprite()
    {
        if(input_movement.x < 0)
        {
            transform.localScale = new Vector3(-1.6f, 1.6f, 1f);
        }
        if(input_movement.x > 0)
        {
            transform.localScale = new Vector3(1.6f, 1.6f, 1f);
        }
    }



    void SetMovementAnim()
    {
        anim.SetFloat("XValue", Mathf.Abs(input_movement.x));
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            interactCollision = collision;
            isInInteractArea = true;
        
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            interactCollision = null;
            isInInteractArea = false;
         
        }
    }



    void DoInteract()
    {
        if(dialogueManager.isTalking == true)
        {
            dialogueManager.DisplayNextSentence();
            return;
        }



        if(interactCollision != null) { 




        if (isInInteractArea)
        {
            interactCollision.GetComponent<Interactable>().Interact();
        }

        }
    }






    void PlayerPositionCheck()
    {
        if (PlayerPrefs.HasKey("lastXPosition"))
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("lastXPosition"), transform.position.y, transform.position.z);
        }
    }



 





}




