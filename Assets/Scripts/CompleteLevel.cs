using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;
    
    public SceneTransition transition;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        transition.FadeToScene(nextLevel);
    }

    public void Menu()
    {
        transition.FadeToScene(menuSceneName);
    }
}
