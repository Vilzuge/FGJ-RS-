using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 15f;
    public Animator animator;
    public SpriteRenderer sprite;
    
    private Rigidbody2D rb;
    private float movement;
    private Turn turn;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpsValue;

    private void Start()
    {
        extraJumps = extraJumpsValue;
        turn = GetComponent<Turn>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        Debug.Log(movement);

        if (movement > 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(movement));
        }

        if (movement == 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(movement));
            animator.SetFloat("Speed-left", Mathf.Abs(movement));
        }

        if (movement < 0)
        {
            animator.SetFloat("Speed-left", Mathf.Abs(movement));
        }

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }


        if (turn.GetCurrentTurn() == TurnState.Dark)
        {
            animator.SetBool("Dark", false);
            rb.gravityScale = 5f;
            jumpForce = 20;

            sprite.flipY = false;
           
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }

        if (turn.GetCurrentTurn() == TurnState.Bright)
        {
            animator.SetBool("Dark", true);
            rb.gravityScale = -5f;
            jumpForce = -20;
            movement *= (-1);

            sprite.flipY = true;


            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }

        }

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

    }
}
