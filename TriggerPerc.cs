using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * When Snare Sphere collides with Snare Cube, gets the Snare State from NoteSnare script,
 * sets the Wwise Snare State, plays Snare event.
 */
public class TriggerPerc : MonoBehaviour
{
    [SerializeField] string wwiseEvent;


    void Start()
    {
        // Initialize State so it doesn't default to None State
        AkSoundEngine.SetState("Perc", "Perc1");
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

        AkSoundEngine.SetState("Perc", ballNoteState);
        AkSoundEngine.PostEvent(wwiseEvent, gameObject);
    }
}
