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
/// Controls the player's input logic.
/// </summary>

public class Player : MonoBehaviour {
    // Movement control
    Rigidbody rb;
    public float speed = 20.0f;
    // GameManager
    public GameManager instance;
    // Gameplay logic
    public int health = 100;
    public bool isInvincible = false;
    public bool gameOver = false;
    // Audio and camera effects.
    public AudioClip[] audioClips = new AudioClip[8];
    private AudioSource audioData;
    private Coroutine animationCamera; // used to control the sine wave effect.

    // Sets game values up.
    private void Start() {
        rb = GetComponent<Rigidbody>();
        health = 100;
        instance.UpdateData(health);
        audioData = gameObject.GetComponent<AudioSource>();
    }

    // Controls input.
    private void Update() {
        if(!gameOver) {
            if(Input.GetKeyDown(KeyCode.R)) { // red potion (health).
                if(health < 100 && instance.potions[0] > 0) {
                    health += 10;
                    instance.potions[0]--;
                    instance.UpdateData(health);
                    PlayAudioSource('u');
                }
            } if (Input.GetKeyDown(KeyCode.G)) { // green potion (endurance).
                if(isInvincible == false && instance.potions[1] > 0) { // only runs if the player has a potion and is not invincible.
                    instance.potions[1]--;
                    UseInvincibility();
                    Invoke("EndInvincibility",5.0f);
                    instance.UpdateData(health);
                    PlayAudioSource('u');
                }
            } if (Input.GetKeyDown(KeyCode.B)) { // blue potion (mana).
                if(isInvincible == false && instance.potions[2] > 0) {
                    instance.potions[2]--;
                    UseInvincibility();
                    Invoke("EndInvincibility",10.0f);
                    instance.UpdateData(health);
                    PlayAudioSource('u');
                }
            }
        }
    }

    // Controls movement.
    // Using FixedUpdate to prevent jagged movement.
    private void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(moveHorizontal,0,moveVertical) * speed);
    }

    // Enables invincibility and begins the sine wave effect that tells the player when they're invincible.
    private void UseInvincibility() {
        isInvincible = true;
        GameObject.Find("Main Camera").GetComponent<SineWave>().enabled = true;
        StartCoroutine(introSinWave(0.02f));
    }

    // Ends invincibility and disables the sine wave effect.
    private void EndInvincibility() {
        isInvincible = false;
        StartCoroutine(exitSineWave(0.02f));
        
    }

    // A coroutine that "fades in" to the effect for visual polish.
    private IEnumerator introSinWave(float value) { // a WaitForSeconds variable is taken here for debug purposes.
        yield return new WaitForSeconds(.001f); // gives time for the camera script to catch up with the coroutine
        for(int i=0;i<20;i++) {
            GameObject.Find("Main Camera").GetComponent<SineWave>().Frequency -= 1.0f;
            GameObject.Find("Main Camera").GetComponent<SineWave>().Amplitude += 0.00025f;
            GameObject.Find("Main Camera").GetComponent<SineWave>().HorizontalOffset += 0.01f;
            yield return new WaitForSeconds(value);
        }
    }

    // A coroutine that "fades out" of the effect for visual polish.
    private IEnumerator exitSineWave(float value) {
        yield return new WaitForSeconds(.001f); // gives time for the camera script to catch up with the coroutine
        for(int i=0;i<20;i++) {
            GameObject.Find("Main Camera").GetComponent<SineWave>().Frequency += 1.0f;
            GameObject.Find("Main Camera").GetComponent<SineWave>().Amplitude -= 0.00025f;
            GameObject.Find("Main Camera").GetComponent<SineWave>().HorizontalOffset -= 0.01f;
            yield return new WaitForSeconds(value);
        }
        GameObject.Find("Main Camera").GetComponent<SineWave>().enabled = false; // disables the effect after it's not noticeable.
    }
    
    // Plays a different audiosource from the player.
    // This is necessary because the interactable objects are being destroyed before they can play the sound. 
    public void PlayAudioSource(char type) {
        switch(type) {
            case('r'):
                audioData.PlayOneShot(audioClips[0],1.0f);
                break;
            case('g'):
                audioData.PlayOneShot(audioClips[1],1.0f);
                break;
            case('b'):
                audioData.PlayOneShot(audioClips[2],1.0f);
                break;
            case('c'):
                audioData.PlayOneShot(audioClips[3],1.0f);
                break;
            case('x'):
                audioData.PlayOneShot(audioClips[4],1.0f);
                break;
            case('w'):
                audioData.PlayOneShot(audioClips[5],1.0f);
                break;
            case('l'):
                audioData.PlayOneShot(audioClips[6],1.0f);
                break;
            case('z'):
                audioData.PlayOneShot(audioClips[7],1.0f);
                break;
            case('u'):
                audioData.PlayOneShot(audioClips[8],1.0f);
                break;
            default:
                Debug.Log("Invalid type.");
                break;
        }
    }
}
