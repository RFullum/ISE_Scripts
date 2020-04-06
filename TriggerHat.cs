using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * When Snare Sphere collides with Hat Cube, gets the Hat State from NoteHat script,
 * sets the Wwise Hat State, plays Hat event.
 */
public class TriggerHat : MonoBehaviour
{
    [SerializeField] string wwiseEvent;
    
    
    void Start()
    {
        {
            // Initialize State so it doesn't default to None State
            //AkSoundEngine.SetState("Hats", "Hat1");
            AkSoundEngine.RegisterGameObj(gameObject);
            AkSoundEngine.SetSwitch("HatSwitch", "Hat1",gameObject);
        }
    }

    /**
     * When Sphere collides with Cube, retrieve Note State associated with
     * that Sphere, set the State using it, and then trigger the sound.
     */
    private void OnCollisionEnter(Collision collision)
    {
        GameObject currentBall = collision.gameObject;

        var ballScript = currentBall.GetComponent<NoteHat>();
        string ballNoteState = ballScript.getNote();
        string openCloseState = ballScript.getOpenClose();

        string hatOC = ballNoteState + "_OC";
        string setOpenCloseState = ballNoteState + "_" + openCloseState;

        AkSoundEngine.SetSwitch("HatSwitch", ballNoteState, gameObject);
        AkSoundEngine.SetSwitch(hatOC, setOpenCloseState, gameObject);
        AkSoundEngine.PostEvent(wwiseEvent, gameObject);
    }
}
