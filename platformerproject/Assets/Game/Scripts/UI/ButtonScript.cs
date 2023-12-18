using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite pressedSprite;


    public void OnPointerDown(PointerEventData eventData)
    {
        buttonImage.sprite = pressedSprite;
        Debug.Log("Pressed");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonImage.sprite = defaultSprite;
        Debug.Log("Released");
        StartCoroutine(StartGameRoutine());
    }

    private IEnumerator StartGameRoutine()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

}
