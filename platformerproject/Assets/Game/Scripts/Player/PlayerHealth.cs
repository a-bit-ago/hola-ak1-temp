using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;

    //Använder en read only property för att använda maxHealth i ett annat script eftersom variabeln "maxHealth" den är private/serialiserad
    public int MaxHealth => maxHealth;
    private int currentHealth;

    private void Start()
    {
        //Precis som i PlayerController så assignar jag currentHealth till maxHealth
        //spelaren startar med maxHealth och använder currentHealth när du förlorar och får liv
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        //currentHealth = currentHealth - amount
        currentHealth -= amount;

        Debug.Log("Player has taken " + amount + ". Player health is now: " + currentHealth);

        //När spelaren har 0 i liv så dyker game over skärmen upp
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        //Exempel i HealthPickup på FindObjectOfType och != / == null
        LogicManager logicManager = FindObjectOfType<LogicManager>();


        if (logicManager != null)
        {
            //Kallar på GameOverPanel funktionen
            logicManager.GameOverPanel();
        }

        //Förstör spelaren eftersom detta scriptet sitter på spelaren.
        Destroy(gameObject);
    }


    public void IncreaseHealth(int amount)
    {
        //currentHealth = currentHealth + amount;
        currentHealth += amount;

        //Som med Mathf.Max så sätter jag två värden, fast med Min så bestämmer jag minimum av de två värden och returerar det minsta värdet
        //I vårt fall använder vi currentHealth så den inte går över maxHealth så man inte får mer än 5 liv när jag plockar upp health.
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        Debug.Log("Player has increased health by " + amount + ". Player has now: " + currentHealth);
    }

}
