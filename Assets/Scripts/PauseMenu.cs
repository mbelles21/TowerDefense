using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;

    public SceneTransition transition;
    public string menuSceneName = "MainMenu";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf); // will do the opposite of whatever it already is

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
            // also update fixedDeltaTime if setting to value other than 0
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        transition.FadeToScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        transition.FadeToScene(menuSceneName);
    }
}
