using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Beat sequencer: Counts beats and sixteenth notes at tempo (beatsPerMinute in Singleton)
 */
public class BPM : MonoBehaviour
{
    // Create instance of class
    private static BPM bpmInstance;

    // Tracks beat divisions
    public static bool beatFull;
    public static bool sixteenthBeatFull;

    // Counts beat divisions
    public static int beatCountFull;
    public static int sixteenthCountFull;

    // length of beat divisions
    private float beatInterval;
    private float sixteenthBeatInterval;

    // initializes timers
    private float beatTimer = 0.0f;
    private float sixteenthBeatTimer = 0.0f;


    /**
     * If instance is empty, make it this script, otherwise destroy
     * instance because it already exists. (Ensures only one instance
     * exists and doesn't get destroyed.)
     */
    private void Awake()
    {
        if (bpmInstance != null && bpmInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            bpmInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    /*
    void Update()
    {
        // Call beatDetection method
        beatDetection();
    }
    */
    private void FixedUpdate()
    {
        beatDetection();
    }

    /**
     * Calculates quarter notes and sixteenth notes
     * Calculates the interval via the singleton's (game manager's) beatsPerMinute variable
     * tracks the elapsed time.
     *
     * When the timer is greater or equal to the interval:
     * -wrap timer, set Full to true, and increment CountFull
     */
    void beatDetection()
    {
        // Full beat count
        beatFull = false;
        beatInterval = 60.0f / Singleton.Instance.beatsPerMinute;  // beatsPerMinute;  // duration of each beat
        beatTimer += Time.deltaTime;
   
        // Full loop
        if (beatTimer >= beatInterval)
        {
            beatTimer -= beatInterval;  // Wraps beatTimer
            beatFull = true;            // Flips bool
            beatCountFull++;            // Increments counter
        }

        // Sixteenth beat count
        sixteenthBeatFull = false;
        sixteenthBeatInterval = beatInterval / 4.0f;
        sixteenthBeatTimer += Time.deltaTime;

        // Eighth loop
        if (sixteenthBeatTimer >= sixteenthBeatInterval)
        {
            sixteenthBeatTimer -= sixteenthBeatInterval;  // wrap eighthBeatTimer
            sixteenthBeatFull = true;                  // flips bool
            sixteenthCountFull++;                      // increments counter
        }
    }
}
