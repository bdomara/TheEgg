
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{

    [SerializeField] private GameObject deathEffect;
    [SerializeField] private LootTable thisLoot;


    public override void Damage(int damage)
    {
        base.Damage(damage);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }

    void Die()
    {

        Instantiate(deathEffect, transform.position, transform.rotation);
        MakeLoot();
        this.transform.parent.gameObject.SetActive(false);
        
    }

    private void MakeLoot()
    {
        if (thisLoot != null)
        {
            Powerup current = thisLoot.LootPowerUp();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }



}