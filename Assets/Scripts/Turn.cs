using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{

    public float turnTime = 5f;
    public Text turnText;
    public TurnState currentTurn = TurnState.Dark;

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
                break;
            case TurnState.Bright:
                turnText.text = "BRIGHT";
                currentTurn = TurnState.Dark;
                break;
            default: 
                Debug.Log("Wut? :D");
                break;
        }
        turnTime = 5f;
    }

    public TurnState GetCurrentTurn()
    {
        return currentTurn;
    }
}
