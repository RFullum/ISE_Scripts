using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnareVerbRTPC : MonoBehaviour
{
    private float verbAmt, verbDecay;
    private float colorG, colorB;
    MapValues mapValues = new MapValues();

    /*
     * Updates snare verb amount based on X position value
     * updates snare verb decay based on Z position value
     * changes colors based on position
     */
    void Update()
    {
        var renderer = GetComponent<Renderer>();
        float xPos = gameObject.transform.position.x;
        float zPos = gameObject.transform.position.z;

        verbAmt = mapValues.remapValues(xPos, -26.0f, 147.0f, 0.0f, 100.0f);
        verbDecay = mapValues.remapValues(zPos, -99.0f, 99.0f, 0.0f, 100.0f);

        AkSoundEngine.SetRTPCValue("SnrVerbAmt", verbAmt);
        AkSoundEngine.SetRTPCValue("SnrVerbDecay", verbDecay);

        // X value changes Green value
        // Z value changes Blue value
        colorG = mapValues.remapValues(verbAmt, 0.0f, 100.0f, 0.0f, 1.0f);
        colorB = mapValues.remapValues(verbDecay, 0.0f, 100.0f, 0.0f, 1.0f);
        renderer.material.SetColor("_Color", new Color(1.0f, colorG, colorB, 1.0f));
    }
}
