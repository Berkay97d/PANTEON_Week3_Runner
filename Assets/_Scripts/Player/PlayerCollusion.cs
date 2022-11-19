using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollusion : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameController.Status = GameStatus.Lost;
        }
        else if(other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            GameController.IncreaseCoin();
        }
        else if (other.CompareTag("Finish"))
        {
            if (GameController.CollectedCoin >= GameController.TargetCoin)
            {
                GameController.Status = GameStatus.Win;
            }
            else
            {
                GameController.Status = GameStatus.Lost;
            }
        }
    }
}
