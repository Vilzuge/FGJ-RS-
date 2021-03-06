using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{

    public float turnTime = 5f;
    
    private Text turnText;
    public TurnState currentTurn = TurnState.Dark;
    private GameObject environment;
    
    private void Start()
    {
        environment = GameObject.Find("Environment");
        turnText = GameObject.Find("Text").GetComponent<Text>();
    }

    
    
    void Update()
    {
        if (turnTime >= 0)
        {
            turnTime -= Time.deltaTime;
            turnText.text = Math.Round(turnTime, 0).ToString();
        }
        else
        {
            ChangeTurn();
        }
    }

    public void ChangeTurn()
    {
        switch (currentTurn)
        {
            case TurnState.Dark:
                currentTurn = TurnState.Bright;
                ToggleColor();
                break;
            case TurnState.Bright:
                currentTurn = TurnState.Dark;
                ToggleColor();
                break;
            default: 
                Debug.Log("Error");
                break;
        }
        turnTime = 5f;
    }


    private void ToggleColor()
    {
        if (!environment) return;
        
        foreach (Transform child in environment.transform)
        {
            var sr = child.GetComponent<SpriteRenderer>();

            if (sr.color == Color.white)
            {
                sr.color = Color.black;
                //sr.sortingOrder = 1;
            } 
            else if (sr.color == Color.black)
            {
                sr.color = Color.white;
                //sr.sortingOrder = 0;
            }
        }
    }

    public TurnState GetCurrentTurn()
    {
        return currentTurn;
    }
}
