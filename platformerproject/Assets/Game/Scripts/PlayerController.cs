using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private float horizontalMovement;

    [Header("Movement Variable")]
    [SerializeField] private float moveSpeed;
    [Header("Jumping Variables")]
    [SerializeField] private float jumpForce;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Vector2 groundCheckSize;
    [SerializeField] private LayerMask groundLayer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        if (IsGrounded())
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * 0.5f);
            }
        }
        
        Debug.Log(horizontalMovement + " Horizontal movement");
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        if (Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer))
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckPoint.position, groundCheckSize);
    }
}
