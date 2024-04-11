using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    private void Start()
    {
        gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        // prevent game over message from being repeated
        if (gameEnded)
        {
            return;
        }
        
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameEnded = true;
        // Debug.Log("Game Over");
        
        gameOverUI.SetActive(true);
    }

    public void LevelComplete()
    {
        gameEnded = true;
        completeLevelUI.SetActive(true);
    }
}
