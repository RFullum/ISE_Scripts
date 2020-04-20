using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controls Organ FX params on the Organ FX Bus
 */
public class OrganFXParams : MonoBehaviour
{
    MapValues mapValues = new MapValues();

    // RTPC names
    private string delFB = "OrganDelayFdbk";
    private string ptchFrq = "OrganPtchShftFltrFrq";
    private string ptchD = "OrganPtchShftDegrees";
    private string tremD = "OrganTremDepth";
    private string tremF = "OrganTremFreq";

    private float rVal, gVal, bVal;


    void Update()
    {
        // Gets ball coords
        var ballPosX = transform.position.x;
        var ballPosY = transform.position.y;
        var ballPosZ = transform.position.z;

        //Remaps position to RTPC values
        float param1 = mapValues.remapValues(ballPosX, -26.0f, 147.0f, 0.0f, 100.0f);
        float param2 = mapValues.remapValues(ballPosZ, -99.0f, 99.0f, 0.0f, 100.0f);
        float height = mapValues.remapValues(ballPosY, 1.5f, 40.0f, 0.0f, 100.0f);

        // Set RTPC values
        AkSoundEngine.SetRTPCValue(tremF, height);
        AkSoundEngine.SetRTPCValue(tremD, param1);
        AkSoundEngine.SetRTPCValue(ptchFrq, param1);
        AkSoundEngine.SetRTPCValue(ptchD, param2);
        AkSoundEngine.SetRTPCValue(delFB, param1 + height);

        // Gets RGB values from position
        rVal = mapValues.remapValues(param1, 0.0f, 100.0f, 0.0f, 1.0f);
        gVal = mapValues.remapValues(param2, 0.0f, 100.0f, 0.0f, 1.0f);
        bVal = mapValues.remapValues(height, 0.0f, 100.0f, 0.0f, 1.0f);

        // Changes color
        var renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", new Color(rVal, gVal, bVal, 1.0f));

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                // Make it stop bouncing or rolling
                if (Input.GetKeyDown(KeyCode.X))
                {
                    var rb = GetComponent<Rigidbody>();
                    rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
                }
            }
        }
    }
}
