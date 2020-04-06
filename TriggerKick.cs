using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * When Kick Sphere collides with Kick Cube, gets the Kick State from NoteKick script,
 * sets the Wwise Kick State, plays Kick event.
 */
public class TriggerKick : MonoBehaviour
{
    [SerializeField] string wwiseEvent;

    
    void Start()
    {
        // Initialize State so it doesn't default to None State
        AkSoundEngine.SetSwitch("Kick", "Kick1_C", gameObject);
    }


    /**
     * When Sphere collides with Cube, retrieve Note State associated with
     * that Sphere, set the State using it, and then trigger the sound.
     */
    private void OnCollisionEnter(Collision collision)
    {
        GameObject currentBall = collision.gameObject;

        var ballScript = currentBall.GetComponent<NoteKick>();
        string ballNoteState = ballScript.getNote();

        AkSoundEngine.SetSwitch("Kick", ballNoteState,gameObject);
        AkSoundEngine.PostEvent(wwiseEvent, gameObject);
    }
}
