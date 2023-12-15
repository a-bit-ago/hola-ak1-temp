using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int coin = 0;

    //Använder detta för att visa exempel på att utnyttja tags, fokusera på detta.
    //Jag gav bara exempel på vad Interfaces är och vad de gör för de som ville lära sig
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coin++;
            Destroy(other.gameObject);
            Debug.Log("Coin: " + coin);
        }

    }
}
