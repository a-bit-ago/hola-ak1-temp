using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingImages : MonoBehaviour
{
    [SerializeField] private RawImage image;
    [SerializeField] private float xPosition;
    [SerializeField] private float yPosition;

    private void Start()
    {
        image = GetComponent<RawImage>();
    }

    private void Update()
    {
        image.uvRect = new Rect(image.uvRect.position + new Vector2(xPosition, yPosition) * Time.deltaTime,
            image.uvRect.size);
    }
}
