﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * When 808 Sphere collides with 808 Cube, gets the Note switch from Note808 script,
 * sets the Wwise Note switch, plays 808 event.
 */
public class TriggerSound : MonoBehaviour
{
    [SerializeField] string wwiseEvent;

    private void Start()
    {
        // Initialize State so it doesn't default to None State
        AkSoundEngine.SetSwitch("Notes808", "C0", gameObject);
    }

    /**
     * When Sphere collides with Cube, retrieve Note State associated with
     * that Sphere, set the State using it, and then trigger the sound.
     */
    private void OnCollisionEnter(Collision collision)
    {
        GameObject currentBall = collision.gameObject;

        var ballScript = currentBall.GetComponent<Note808>();
        string ballNoteState = ballScript.getNote();

        AkSoundEngine.SetSwitch("Notes808", ballNoteState, gameObject);
        AkSoundEngine.PostEvent(wwiseEvent, gameObject);
    }
}
