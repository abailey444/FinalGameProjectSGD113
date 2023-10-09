//////////////////////////////////////////////////////
// Assignment/Lab/Project: Final Game
//Name: Avery Bailey
//Section: 2022FA.SGD.113.2602
//Instructor: Lydia Granholm
// Date: 10/09/2023
//////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Controls the gamestate. 
/// Updates the UI for game information, used as a reference for other scripts, controls level wins/loss.
/// </summary>

public class GameManager : MonoBehaviour {
    // Array controls potions the player currently has.
    // 0 = Red
    // 1 = Green
    // 2 = Blue
    public int[] potions = new int[] {0,0,0};

    // Controls the coins the player has picked up.
    public int coins = 0;
    
    // Game Objects
    public GameObject[] panels = new GameObject[3];
    public TMP_Text healthText;
    public TMP_Text coinsText;
    public TMP_Text redPotion;
    public TMP_Text bluePotion;
    public TMP_Text greenPotion;
    public GameObject player;

    // Updates the UI and calls the win/loss checks. 
    public void UpdateData(int hp) {
        if(GameObject.Find("ControlLevel").GetComponent<ControlLevel>().level == 3) { // changes the UI when it's the final level.
            CheckLevelWin(true);
        } else {
            CheckLevelWin(false);
        } if(hp == 0) {
            HandleGameOver();
        } healthText.text = "HEALTH: " + hp;
        coinsText.text = "COINS COLLECTED: " + coins;
        redPotion.text = "HEALTH POTIONS: " + potions[0].ToString();
        bluePotion.text = "MANA POTIONS: " + potions[2].ToString();
        greenPotion.text = "ENDURANCE POTIONS: " + potions[1].ToString();
    }

    // Changes the UI on game loss, plays a loss sound.
    public void HandleGameOver() {
        player.GetComponent<Player>().gameOver = true;
        panels[0].gameObject.SetActive(true);
        panels[2].gameObject.SetActive(false);
        player.GetComponent<Player>().PlayAudioSource('l');
    }

    // Changes the UI on game win, plays a win sound.
    // The UI panel that is set to active will change whether it's the third level or not.
    public void CheckLevelWin(bool useLevelThreeMenu) {
        if(coins == 10 && useLevelThreeMenu == false) {
            player.GetComponent<Player>().gameOver = true;
            panels[1].gameObject.SetActive(true);
            panels[2].gameObject.SetActive(false);
            player.GetComponent<Player>().PlayAudioSource('w');
        } else if(coins == 10 && useLevelThreeMenu == true) { // shows a different panel if it is the last level.
            panels[3].gameObject.SetActive(true);
            panels[2].gameObject.SetActive(false);
            player.GetComponent<Player>().PlayAudioSource('w');
        }
    }

    // Goes to the main menu scene.
    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    // Goes to the next level depending upon the public variable ControlLevel.level (int).
    // This is necessary because the third level should not have the "Next Level" button, so a new panel is required.
    public void GotoNextLevel() {
        switch(GameObject.Find("ControlLevel").GetComponent<ControlLevel>().level) { // references the public variable in each scene that is controlled by ControlLevel.cs
            case(1):
                SceneManager.LoadScene("LevelTwo");
                break;
            case(2):
                SceneManager.LoadScene("LevelThree");
                break;
            default: // error testing
                Debug.Log("Error in level selection");
                break;
        }
    }

    // Quits the game.
    public void QuitGame() {
        Application.Quit();
    }

}
