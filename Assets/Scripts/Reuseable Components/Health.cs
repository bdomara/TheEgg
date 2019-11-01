using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Tooltip("Max and current health \n Set this to one for pots")]
    [Header("Health Values")]
    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;


    public void SetHealth(int amount)
    {
        currentHealth = amount;
    }

    public virtual void Damage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    public virtual void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Kill()
    {
        currentHealth = 0;
    }

    public void FullHeal()
    {
        currentHealth = maxHealth;
    }
}