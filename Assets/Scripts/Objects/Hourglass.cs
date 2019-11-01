using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hourglass : Powerup
{
    public FloatValue healthContainers;
    public FloatValue playerHealth;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthContainers.value += 1;
            playerHealth.value = healthContainers.value * 2;
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
