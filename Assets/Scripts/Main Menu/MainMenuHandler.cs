//////////////////////////////////////////////////////
// Assignment/Lab/Project: Final Game
//Name: Avery Bailey
//Section: 2022FA.SGD.113.2602
//Instructor: Lydia Granholm
// Date: 10/09/2023
//////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Controls the main menu logic.
/// </summary>

public class MainMenuHandler : MonoBehaviour {
    // An array of panels on the main menu.
    public GameObject[] panels = new GameObject[2];
    // 0 = MainMenu
    // 1 = Instructions

    // Sets up the panels.
    private void Start() {
        OnClickReturn();
    }

    // Changes the scene to the first level.
    public void OnClickPlay() {
        SceneManager.LoadScene("LevelOne");
    }

    // Quits the application.
    public void OnClickQuit() {
        Application.Quit();
    }

    // Changes the panel to the instructions panel.
    public void OnClickInstructions() {
        panels[0].gameObject.SetActive(false);
        panels[1].gameObject.SetActive(true);
    }

    // Enables the main menu panel.
    public void OnClickReturn() {
        panels[0].gameObject.SetActive(true);
        panels[1].gameObject.SetActive(false);
    }
}
