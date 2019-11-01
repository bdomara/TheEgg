using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOnContact : Heal
{
    [SerializeField] private string otherString;
    [SerializeField] private int healAmount;
    [SerializeField] private FloatValue currentHealth;
    [SerializeField] private FloatValue maxHealth;
    [SerializeField] private Signal healthSignal;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherString))
        {
            Health temp = other.gameObject.GetComponent<Health>();
            if (temp)
            {
                ApplyHealing(temp, healAmount);
                SetCurrentHealth(healAmount);
                healthSignal.Raise();
                Destroy(this.gameObject);
            }
        }
    }

    public void SetCurrentHealth(int amountToHeal)
    {
        currentHealth.value += healAmount;
        if (currentHealth.value > maxHealth.value)
        {
            currentHealth.value = maxHealth.value;
        }
    }
}
