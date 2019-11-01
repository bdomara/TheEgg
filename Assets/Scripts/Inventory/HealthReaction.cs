using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReaction : MonoBehaviour
{
    [SerializeField] private FloatValue playerHealth;
    [SerializeField] private FloatValue maxHealth;
    [SerializeField] public Signal healthSignal;

    public void Use(int amountToIncrease)
    {
        playerHealth.value += amountToIncrease;
        if (playerHealth.value > maxHealth.value)
        {
            playerHealth.value = maxHealth.value;
        }
        healthSignal.Raise();
    }
}
