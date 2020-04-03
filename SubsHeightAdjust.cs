using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Adjust object height using values from SubsMeterRTPC script
 */
public class SubsHeightAdjust : MonoBehaviour
{
    // Make height available publicly
    public float cylinderHeight;

    // To scale meter values to adjust height
    private float scaleVal = 20.0f;
    private float scaleX = 10.0f;
    private float scaleY = 0.0f;
    private float scaleZ = 10.0f;

    MapValues mapValues = new MapValues();


    /**
     * Gets meter value from SubsMeterRtpc script, creates a value floor at -80dB,
     * remaps values to useable range, and updates the scale (height) of the object
     * in the Y axis.
     */
    private void FixedUpdate()
    {
        float meterVal = SubsMeterRTPC.meterValue;

        if (meterVal <= -80.0f)
            meterVal = -80.0f;

        float scaleMeterVal = mapValues.remapValues(meterVal, -80.0f, 10.0f, 0.12f, scaleVal);
        transform.localScale = new Vector3(scaleX, scaleMeterVal, scaleZ);
        cylinderHeight = scaleMeterVal;
    }

}


