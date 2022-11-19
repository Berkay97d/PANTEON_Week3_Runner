using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text collectedCoinText;
    [SerializeField] private Canvas beforeGame;
    [SerializeField] private Canvas inGame;
    [SerializeField] private Canvas winGame;
    [SerializeField] private Canvas loseGame;
    [SerializeField] private GameObject inputCanvas;

    

    private void Update()
    {
        CoinUı();
        HandleUI();
    }

    private void CoinUı()
    {
        collectedCoinText.text = GameController.CollectedCoin + "/" + GameController.TargetCoin;
    }

    public void StartGame()
    {
        GameController.isLevelStarted = true;
        beforeGame.gameObject.SetActive(false);
        inGame.gameObject.SetActive(true);
        inputCanvas.SetActive(true);
    }


    private void HandleUI()
    {
        if (GameController.Status == GameStatus.Lost)
        {
            loseGame.gameObject.SetActive(true);
            inputCanvas.SetActive(false);
        }
        else if (GameController.Status == GameStatus.Win)
        {
            winGame.gameObject.SetActive(true);
            inputCanvas.SetActive(false);
        }
    }

    public void RestartGame()
    {
        GameController.Status = GameStatus.Empty;
        GameController.isLevelStarted = false;
        GameController.CollectedCoin = 0;
        SceneManager.LoadScene(0);
    }
    
}
