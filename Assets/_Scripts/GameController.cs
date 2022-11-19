using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus
{
    Empty,
    Win,
    Lost
}

public static class GameController
{
    public static int CollectedCoin = 0;
    public static int TargetCoin = 35;
    public static GameStatus Status = GameStatus.Empty;

    public static bool isLevelStarted = false;
    
    public static void IncreaseCoin()
    {
        CollectedCoin++;
        
    }
    
    public static void ResetCoin()
    {
        CollectedCoin = 0;
    }
}
