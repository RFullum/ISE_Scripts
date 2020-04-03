using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Adjust object height using values from ElevatorSubsRTPC script
 */
public class ElevatorSubsHeight : MonoBehaviour
{
    // Instance of MapValues script
    MapValues mapValues = new MapValues();

    // Member Variables
    private float scaleVal = 20.0f;
    private float posX = 20.0f;
    //private float posY = 0.12f;
    private float posZ = 20.0f;


    /**
     * Gets meter value from ElevatorSubsRTPC script, creates a value floor at -80dB,
     * remaps values to useable range, and updates the position of the object
     * in the Y axis.
     */
    private void FixedUpdate()
    {
        float meterVal = ElevatorSubsRTPC.meterValue;

        if (meterVal <= -80.0f)
            meterVal = -80.0f;

        float scaleMeterVal = mapValues.remapValues(meterVal, -80.0f, 10.0f, 0.12f, scaleVal);
        transform.position = new Vector3(posX, scaleMeterVal, posZ);
    }
}
