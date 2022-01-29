using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 15f;
    public Rigidbody2D rb;
    float movement;
    public Turn turn;

    private void Start()
    {
        turn = GetComponent<Turn>();
    }

    void Update()
    {
        if (turn.GetCurrentTurn() == TurnState.Dark)
        {
            rb.gravityScale = 5f;
            jumpForce = 15;
            movement = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        
        if (turn.GetCurrentTurn() == TurnState.Bright)
        {
            rb.gravityScale = -5f;
            jumpForce = -15;
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
