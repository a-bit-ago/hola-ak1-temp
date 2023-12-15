using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackage : MonoBehaviour, ICollectible
{
    private int maxHealth = 5;

    public void Collect()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();

        if(playerHealth == null) return;

        //Kallar read only property så man healar upp till maxHealth som är satt i PlayerHealth scriptet.
        playerHealth.IncreaseHealth(playerHealth.MaxHealth);

        Destroy(gameObject);

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }
}
