using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{

    public Turn currentTurn;
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject player = collision.gameObject;
            if (player)
            {
                player.GetComponent<Turn>().ChangeTurn();
                Destroy(gameObject);
            }
        }
    }
    
    

}
