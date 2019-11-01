/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    [Header("Contents")]
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public BoolValue storedOpen;

    [Header("Signals and Dialog")]
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;

    [Header("Animation")]
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = storedOpen.RuntimeValue;
        if(isOpen)
        {
            anim.SetBool("opened", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ActionIcon") && playerInRange)
        {
            if (!isOpen)
            {
                OpenChest();
            }
            //open chest
            else
            {
                ChestAlreadyOpen();
                // chest is already open
            }
        }
    }

    public void OpenChest()
    {
        // Dialog window on
        dialogBox.SetActive(true);
        // dialog text = contents text
        dialogText.text = contents.itemDescription;
        // add contents to the inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        // Raise the signal to the player to animate
        raiseItem.Raise();
        // raise the context clue
        context.Raise();
        // set the chest to opened
        isOpen = true;
        // animate chest
        anim.SetBool("opened", true);
        storedOpen.RuntimeValue = isOpen;

    }
    public void ChestAlreadyOpen()
    {
        // Dialog off
        dialogBox.SetActive(false);
        // raise the signal to the player to stop animating
        raiseItem.Raise();
        playerInRange = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;

        }
    }
}*/

using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    [Header("Contents")]
    [SerializeField] private Item myItem;
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private bool isOpen;
    [SerializeField] private BoolValue openValue;

    [SerializeField] private AnimatorController anim;

    [Header("Signals and Dialog")]
    [SerializeField] private Signal chestNotification;
    [SerializeField] private bool dialogActive = false;
    public GameObject dialogBox;
    public Text dialogText;
    //[SerializeField] private SpriteValue spriteValue;
    //[SerializeField] private StringValue itemString;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = openValue.value;
        if (isOpen)
        {
            anim.SetAnimParameter("opened", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetButtonDown("ActionIcon"))
        {
            if (isOpen && dialogActive == false)
            {
                //chestNotification.Raise();
                return;
            }
            DisplayContents();
        }
    }


    void DisplayContents()
    {
        dialogActive = !dialogActive;
        // Dialog window on
        dialogBox.SetActive(dialogActive);
        // dialog text = contents text
        dialogText.text = myItem.itemDescription;
        // add contents to the inventory
        playerInventory.AddItem(myItem);
        playerInventory.currentItem = myItem;
        // Raise the signal to the player to animate
        chestNotification.Raise();
        // set the chest to opened
        isOpen = true;
        // animate chest
        anim.SetAnimParameter("opened", true);
        openValue.value = isOpen;
        if(dialogActive == true)
        {
            // raise the context clue
            mySignal.Raise();
        }

    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = true;
            if (!isOpen)
            {
                mySignal.Raise();
            }
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = false;
            if (!isOpen)
            {
                mySignal.Raise();
            }
        }
    }
}

