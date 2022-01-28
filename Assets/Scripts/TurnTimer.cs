using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnTimer : MonoBehaviour
{

    public float turnTime = 3f;
    public Text turnText;
    public TurnState currentTurn = TurnState.Evil;

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
            case TurnState.Evil:
                turnText.text = "NORMAL";
                Debug.Log("Normal turn started");
                currentTurn = TurnState.Good;
                break;
            case TurnState.Good:
                turnText.text = "EVIL";
                currentTurn = TurnState.Evil;
                Debug.Log("Evil turn started");
                break;
            default: 
                Debug.Log("Wut? :D");
                break;
        }
        turnTime = 3f;
    }

    public TurnState GetCurrentTurn()
    {
        return currentTurn;
    }
}
