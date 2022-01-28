using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public TurnTimer turnTimer;

    private void Start()
    {
        turnTimer = GetComponent<TurnTimer>();
    }

    void Update()
    {
        if (turnTimer.GetCurrentTurn() == TurnState.Evil)
        {
            movement.x = Input.GetAxisRaw("HorizontalEvil");
            movement.y = Input.GetAxisRaw("VerticalEvil");
        }
        
        if (turnTimer.GetCurrentTurn() == TurnState.Good)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
