using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SceneTransition transition;
    public string menuSceneName = "MainMenu";

    public void Retry()
    {
        // to restart the current scene
        transition.FadeToScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        transition.FadeToScene(menuSceneName);
    }
}
