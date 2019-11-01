
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveItem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer mySprite;
    //[SerializeField] private SpriteValue receivedSprite;
    [SerializeField] private AnimatorController anim;
    [SerializeField] private StateMachine myState;
    [SerializeField] private bool isActive = false;

    //[Header("Dialog")]
    [SerializeField] private Signal receivedItem;

    [SerializeField] private Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        mySprite.enabled = false;
    }


    public void ChangeSpriteState()
    {
        //Debug.Log(isActive);
        isActive = !isActive;
        //Debug.Log(isActive);
        if (isActive)
        {
            DisplaySprite();
        }
        else
        {
            DisableSprite();
        }
    }


    void DisplaySprite()
    {
        anim.SetAnimParameter("receive item", true);
        myState.ChangeState(GenericState.receiveItem);
        mySprite.sprite = playerInventory.currentItem.itemSprite;
        mySprite.enabled = true;

        // DisableSprite();

        /* else
         {
             anim.SetAnimParameter("receive item", false);
             currentState = PlayerState.idle;
             receivedItemSprite.sprite = null;
         }*/

        /*myState.ChangeState(GenericState.receiveItem);
        mySprite.enabled = true;
        mySprite.sprite = receivedSprite.value;
        anim.SetAnimParameter("receive item", true);
        dialogNotification.Raise();*/
    }


    void DisableSprite()
    {
        //Debug.Log("DisableSprite called");
        anim.SetAnimParameter("receive item", false);
        myState.ChangeState(GenericState.idle);
        mySprite.sprite = null;
        mySprite.enabled = false;

        /*myState.ChangeState(GenericState.idle);
        mySprite.enabled = false;
        dialogNotification.Raise();*/

    }
}
