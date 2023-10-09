//////////////////////////////////////////////////////
// Assignment/Lab/Project: Final Game
//Name: Avery Bailey
//Section: 2022FA.SGD.113.2602
//Instructor: Lydia Granholm
// Date: 10/09/2023
//////////////////////////////////////////////////////

/// <summary>
/// Controls where the camera is.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float distanceFromTargetY = 5.0f;
    public GameObject PlayerObj;

    // Changes the position of the camera corresponding with the player's location.
    // The camera is at a constant Y height, distanceFromTargetY, which is controlled within in the inspector.
    void FixedUpdate() {
        Vector3 PlayerPosition = PlayerObj.transform.transform.position;
        gameObject.transform.position = new Vector3(PlayerPosition.x, PlayerPosition.y + distanceFromTargetY, PlayerPosition.z);
    }
}
