using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Ett exempel på att istället för att använda tag så letar jag efter objektet som har "PlayerHealth" scriptet på sig.
        //När spelaren kolliderar med fienden så kallar jag TakeDamage funktionen.
        var player = other.collider.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);
        }

    }
}
