﻿/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool active;
    public BoolValue storedValue;
    public Sprite activeSprite;
    private SpriteRenderer mySprite;
    public Door thisDoor;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        active = storedValue.RuntimeValue;
        if(active)
        {
            ActivateSwitch();
        }
        
    }

    public void ActivateSwitch()
    {
        active = true;
        storedValue.RuntimeValue = active;
        thisDoor.Open();
        mySprite.sprite = activeSprite;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // is it the player?
        if(collision.CompareTag("Player"))
        {
            ActivateSwitch();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/
