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
/// Runs when the player object enters a trigger, controls the outcome.
/// </summary>

public class Interact : MonoBehaviour {
    public GameManager instance;
    public GameObject player;
    public GameObject particles;
    public char type;

    // The audiosource that is played depends on the public type variable. 
    // This is important because it allows each prefab to be assigned differently based on what you want it to do.
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Entered");
        switch(type) {
            case('r'):
                instance.potions[0]++;
                instance.UpdateData(player.GetComponent<Player>().health);
                player.GetComponent<Player>().PlayAudioSource(type);
                break;
            case('g'):
                instance.potions[1]++;
                instance.UpdateData(player.GetComponent<Player>().health);
                player.GetComponent<Player>().PlayAudioSource(type);
                break;
            case('b'):
                instance.potions[2]++;
                instance.UpdateData(player.GetComponent<Player>().health);
                player.GetComponent<Player>().PlayAudioSource(type);
                break;
            case('c'):
                instance.coins++;
                instance.UpdateData(player.GetComponent<Player>().health);
                player.GetComponent<Player>().PlayAudioSource(type);
                break;
            case('x'):
                if(player.GetComponent<Player>().isInvincible) { // checks if the player is invincible, if so, the other logic is not necessary.
                    player.GetComponent<Player>().PlayAudioSource('z');
                } else { 
                    player.GetComponent<Player>().health -= 10;
                    Debug.Log(player.GetComponent<Player>().health);
                    instance.UpdateData(player.GetComponent<Player>().health);
                    player.GetComponent<Player>().PlayAudioSource('x');
                } break;
            default:
                Debug.Log("Invalid type.");
                break;
        }
        Destroy(gameObject,0); Destroy(particles,0); // destroying a separate particles GameObject is necessary because it leaves the particles if you only destroy the parent object for some reason.
    }
}
