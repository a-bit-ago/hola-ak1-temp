using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//using TMPro för att använda TextMeshProUGUI klassen
//using UnityEngine.UI för vanlig text

public class Coin : MonoBehaviour, ICollectible
{
    /// <summary>
    /// variabeln är statisk eftersom den delar över alla instancer av coin classen, den bidrar till samma antal
    /// det innebär att det ger ett globalt antal som samlas inne i spelet istället för individuella antal för varje
    /// separat coin-object
    /// </summary>
    private static int coin = 0;

    [SerializeField] private TextMeshProUGUI coinText;
    private void Start()
    {
        coinText.text = "CoinText: " + coin;
    }

    public void Collect()
    {
        //Lägger på hur många coins spelaren har plockat upp och uppdaterar texten, den tar även sönder objektet
        coin++;
        coinText.text = "CoinText: " + coin;
        Destroy(gameObject);
        Debug.Log("Coin collected: " + coin);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }
}
