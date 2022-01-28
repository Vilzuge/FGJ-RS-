using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnTimer : MonoBehaviour
{

    public float turnTime = 3f;
    public bool isEvilTurn = true;
    public Text turnText;

    public enum TurnState
    {
        Good,
        Evil
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

    public void ChangeTurn()
    {
        isEvilTurn = !isEvilTurn;
        
        if (isEvilTurn)
        {
            turnText.text = "EVIL";
        }

        if (!isEvilTurn)
        {
            turnText.text = "NORMAL";
        }

        turnTime = 3f;
    }
}
