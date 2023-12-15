using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour,ICollectible
{
    private int healthAmount = 1;


    public void Collect()
    {
        //Jag använder FindObjectOfType så går den igenom alla objekt som har player health som innehåller PlayerHealth
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();

        // != är en inte lika med operator, varianten är == null så menas det att det är sant
        // null är en form av en avsaknad av referens, så att säga att den inte finns
        // Så om playerHealth != null, så betyder att referensen finns.
        if (playerHealth != null)
        {
            playerHealth.IncreaseHealth(healthAmount);
        }
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Om spelaren har "Player" tag så kan spelaren interacta
        if (other.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }
}
