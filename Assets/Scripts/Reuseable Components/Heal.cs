using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public void ApplyHealing(Health otherHealth, int amountToHeal)
    {
        if (otherHealth)
        {
            otherHealth.Heal(amountToHeal);
        }
    }
}

