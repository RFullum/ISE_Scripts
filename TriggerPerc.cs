using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * When Snare Sphere collides with Perc Cube, gets the Perc State from NotePerc script,
 * sets the Wwise Perc State, plays Snare event.
 */
public class TriggerPerc : MonoBehaviour
{
    [SerializeField] string wwiseEvent;


    void Start()
    {
        // Initialize State so it doesn't default to None State
        AkSoundEngine.SetSwitch("Perc", "Perc1", gameObject);
    }

    /**
     * When Sphere collides with Cube, retrieve Note State associated with
     * that Sphere, set the State using it, and then trigger the sound.
     */
    private void OnCollisionEnter(Collision collision)
    {
        GameObject currentBall = collision.gameObject;

        var ballScript = currentBall.GetComponent<NotePerc>();
        string ballNoteState = ballScript.getNote();

        AkSoundEngine.SetSwitch("Perc", ballNoteState, gameObject);
        AkSoundEngine.PostEvent(wwiseEvent, gameObject);
    }
}
