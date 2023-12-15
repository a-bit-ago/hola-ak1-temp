using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{

    [SerializeField] private GameObject gameOverPanel;

    //Sätter denna till false i Start så objektet inaktiveras när jag spelar
    private void Start()
    {
        gameOverPanel.SetActive(false);
    }


    //Kallar på denna funktionen i PlayerHealth
    public void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }


    //Använder denna funktionen i GameOverPanel UI Button
    public void PlayAgain()
    {
        //Laddar första scenen i Build Settings igen när jag trycker på knappen
        SceneManager.LoadScene(0);
    }



}
