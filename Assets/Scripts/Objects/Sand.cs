using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : Powerup
{
    [SerializeField] private FloatValue playerHealth;
    [SerializeField] private FloatValue maxHealth;
    [SerializeField] private float amountToIncrease;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        playerHealth.value += amountToIncrease;
        if (playerHealth.value > maxHealth.value)
        {
            playerHealth.value = maxHealth.value;
        }
    
    // Raise power up signal and destroy object
        powerupSignal.Raise();
        Destroy(this.gameObject);
    }
}
