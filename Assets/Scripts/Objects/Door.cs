/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : Interactable
{
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    public BoxCollider2D triggerCollider;
    public Animator anim;

    private void Update()
    {
        if(Input.GetButtonDown("actionIcon"))
        {
            if(playerInRange && thisDoorType == DoorType.key)
            {
                //Does the player have a key?
                if(playerInventory.numberOfKeys > 0)
                {
                    //remove a player key
                    playerInventory.numberOfKeys--;
                    //if so, then call the open method
                    Open();
                }
            }
        }
    }

    public void Open()
    {
        //Turn off the door's sprite renderer/animate open door
        anim.SetBool("open", true);
        //Set open to true
        open = true;    
        //turn off the door's box collider
        physicsCollider.enabled = false;
        // turn off door's trigger collider
        triggerCollider.enabled = false;

    }

    public void Closed()
    {
        //Turn on the door's sprite renderer/animate open door
        anim.SetBool("open", false);
        //Set open to false
        open = false;
        //turn on the door's box collider
        physicsCollider.enabled = true;
        // turn on door's trigger collider
        triggerCollider.enabled = true;


    }

}*/

