using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7.5f;

    void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;

        }

        Vector3 moveDirection = new Vector2(inputVector.x, 0);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        Debug.Log("Input: " + inputVector);
    }
}
