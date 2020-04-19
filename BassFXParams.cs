using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controls Bass FX parameters based on sphere position
 */
public class BassFXParams : MonoBehaviour
{
    MapValues mapValues = new MapValues();

    // Some RTPC names
    private string bpDist = "BassDistBypass";
    private string bpChrs = "BassChorusBypass";
    private string bpTrem = "BassTremBypass";
    private string delDW = "BassDelayWetDry";

    // Values for RTPC settings
    private float bypassed = 0.0f;
    private float activeFX = 100.0f;
    private float fiftyFiftyDryWet = 50.0f;

    // true = bypassed; false = active;
    private bool chrsToggle = true;
    private bool distToggle = true;
    private bool tremToggle = true;

    // Color variables
    private Color color;
    private float inactiveColor = 0.25f;
    private float activeColor = 0.75f;
    private float rVal, gVal, bVal;



    /*
     * Initializes FX to bypassed and colors to inactive
     */
    private void Start()
    {
        AkSoundEngine.SetRTPCValue(bpChrs, bypassed);
        AkSoundEngine.SetRTPCValue(bpDist, bypassed);
        AkSoundEngine.SetRTPCValue(bpTrem, bypassed);
        rVal = gVal = bVal = inactiveColor;
    }


    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Toggles bypasses true and false
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    chrsToggle = !chrsToggle;
                }

                if (Input.GetKeyDown(KeyCode.N))
                {
                    distToggle = !distToggle;
                }

                if (Input.GetKeyDown(KeyCode.H))
                {
                    tremToggle = !tremToggle;
                }

                // Make it stop bouncing or rolling
                if (Input.GetKeyDown(KeyCode.X))
                {
                    var rb = GetComponent<Rigidbody>();
                    rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
                }
            }
        }

        /*
         * Uses toggle state to bypass or activate the FX unit
         * and set color values
         */
        if (chrsToggle == true)
        {
            AkSoundEngine.SetRTPCValue(bpChrs, bypassed);
            rVal = inactiveColor;
        }
        else if (chrsToggle == false)
        {
            AkSoundEngine.SetRTPCValue(bpChrs, activeFX);
            rVal = activeColor;
        }

        if (distToggle == true)
        {
            AkSoundEngine.SetRTPCValue(bpDist, bypassed);
            gVal = inactiveColor;
        }
        else if (distToggle == false)
        {
            AkSoundEngine.SetRTPCValue(bpDist, activeFX);
            gVal = activeColor;
        }

        if (tremToggle == true)
        {
            AkSoundEngine.SetRTPCValue(bpTrem, bypassed);
            bVal = inactiveColor;
        }
        else if (tremToggle == false)
        {
            AkSoundEngine.SetRTPCValue(bpTrem, activeFX);
            bVal = activeColor;
        }

        

        /*
         * If any of the other FX units are active, the delay is 50/50 dry/wet
         * If they're all inactive, the delay is full wet
         */
        if (chrsToggle == false || distToggle == false || tremToggle == false)
        {
            AkSoundEngine.SetRTPCValue(delDW, fiftyFiftyDryWet);
        }
        else if (chrsToggle == true && distToggle == true && tremToggle == true)
        {
            AkSoundEngine.SetRTPCValue(delDW, activeFX);
        }

        // Changes color based on bypass activity
        var renderer = GetComponent<Renderer>();
        color = new Color(rVal, gVal, bVal, 1.0f);
        renderer.material.SetColor("_Color", color);

        // Gets ball coords
        var ballPosX = transform.position.x;
        var ballPosY = transform.position.y;
        var ballPosZ = transform.position.z;

        // Remaps ball coords to RTPC useable vals
        float param1 = mapValues.remapValues(ballPosX, -26.0f, 147.0f, 0.0f, 100.0f);
        float param2 = mapValues.remapValues(ballPosZ, -99.0f, 99.0f, 0.0f, 100.0f);
        float height = mapValues.remapValues(ballPosY, 1.5f, 40.0f, 0.0f, 100.0f);

        // Sets RTPC Vals
        AkSoundEngine.SetRTPCValue("BassChorus", param1);
        AkSoundEngine.SetRTPCValue("BassChorus2", param2);
        AkSoundEngine.SetRTPCValue("BassDistDrive", param1);
        AkSoundEngine.SetRTPCValue("BassDistRect", param2);
        AkSoundEngine.SetRTPCValue("BassTremDepth", param1);
        AkSoundEngine.SetRTPCValue("BassTremFreq", param2);
        AkSoundEngine.SetRTPCValue("BassDelayFeedback", height); 
        
    }
}
