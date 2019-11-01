﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityFrames: MonoBehaviour
{

    [SerializeField] private SpriteRenderer mySprite;
    [SerializeField] private Color flashColor;
    [SerializeField] private int numberOfFlashes;
    [SerializeField] private float flashDelay;
    [SerializeField] private Collider2D triggerCollider;
    private bool isFlashing = false;

    public void StartFlash()
    {
        if (!isFlashing)
        {
            StartCoroutine(FlashCo());
        }
    }

    public IEnumerator FlashCo()
    {
        isFlashing = true;
        triggerCollider.enabled = false;
        for (int i = 0; i < numberOfFlashes; i++)
        {
            if (mySprite)
            {
                mySprite.color = flashColor;
                yield return new WaitForSeconds(flashDelay);
                mySprite.color = Color.white;
                yield return new WaitForSeconds(flashDelay);
            }
        }
        isFlashing = false;
        triggerCollider.enabled = true;
    }
}