using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 15f;
    public Rigidbody2D rb;
    float movement;
    public TurnTimer turnTimer;

    private void Start()
    {
        turnTimer = GetComponent<TurnTimer>();
    }

    void Update()
    {
        if (turnTimer.GetCurrentTurn() == TurnState.Evil)
        {
            movement = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        
        if (turnTimer.GetCurrentTurn() == TurnState.Good)
        {
            movement = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }
}
