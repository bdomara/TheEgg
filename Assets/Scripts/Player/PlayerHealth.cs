using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private InvincibilityFrames flash;
    [SerializeField] private FloatValue maxHealthValue;
    [SerializeField] private FloatValue currentHealthValue;
    [SerializeField] private Signal updateHeartsUI;

    private void Start()
    {
        SetHealth((int)maxHealthValue.value);
        currentHealthValue.value = maxHealthValue.value;
        updateHeartsUI.Raise();

    }

    public override void Damage(int damage)
    {
        base.Damage(damage);
        currentHealthValue.value -= damage;
        updateHeartsUI.Raise();
        if (currentHealth > 0)
        {
            if (flash)
            {
                flash.StartFlash();
            }
        }
    }

    /*public override void Heal(int amount)
    {
        base.Heal(amount);
        currentHealthValue.value += amount;
        updateHeartsUI.Raise();
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }*/
}
