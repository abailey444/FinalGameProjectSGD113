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

/// <summary>
/// Allows a public game object to control the level variable.
/// In each scene, this public variable has a different value.
/// LevelOne has a value of 1, etc.
/// This variable is used throughout the project.
/// </summary>

public class ControlLevel : MonoBehaviour {
    public int level;
    void Start() {
        Debug.Log("The level is currently level " + level);
    }
}
