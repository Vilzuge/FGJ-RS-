using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{

    public float turnTime = 5f;
    
    public Text turnText;
    public TurnState currentTurn = TurnState.Dark;
    public GameObject environment;

    private void Start()
    {
        environment = GameObject.Find("Environment");
    }

    void Update()
    {
        if (turnTime >= 0)
        {
            turnTime -= Time.deltaTime;
        }
        else
        {
            ChangeTurn();
        }
    }

    private void ChangeTurn()
    {
        switch (currentTurn)
        {
            case TurnState.Dark:
                turnText.text = "DARK";
                currentTurn = TurnState.Bright;
                ToggleColor();
                break;
            case TurnState.Bright:
                turnText.text = "BRIGHT";
                currentTurn = TurnState.Dark;
                ToggleColor();
                break;
            default: 
                Debug.Log("Wut? :D");
                break;
        }
        turnTime = 5f;
    }


    private void ToggleColor()
    {
        if (!environment) return;
        
        foreach (Transform child in environment.transform)
        {
            SpriteRenderer sr = child.GetComponent<SpriteRenderer>();

            if (sr.color == Color.white)
            {
                sr.color = Color.black;
                sr.sortingOrder = 1;
            }

            if (sr.color == Color.black)
            {
                sr.color = Color.white;
                sr.sortingOrder = 0;
            }
        }
    }

    public TurnState GetCurrentTurn()
    {
        return currentTurn;
    }
}
