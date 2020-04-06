using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Changes color of object based on Wwise Meter values
 */
public class ColorChangerHighs : MonoBehaviour
{
    // Instance of Color object
    Color newColor;

    // creates instance of MapValues to map meter values between 0.0 and 1.0 for RGBA values
    MapValues mapValues = new MapValues();

    void Start()
    {
        // Initializes color
        newColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        var colorRender = gameObject.GetComponent<Renderer>();
        colorRender.material.SetColor("_Color", newColor);

    }

    void Update()
    {
        // Gets Wwise Master Bus level real-time
        float meterVal = HighsMeterRTPC.meterValue;

        /**
         * Takes meterVal from Wwise and remaps values between 1.0f and 0.0f
         * uses scaledMeterVal to update the R and G arguments for the RGBA color
         * Sets material color to new color values
         */
        float scaleRedVal = mapValues.remapValues(meterVal, -80.0f, 10.0f, 1.0f, 1.0f);
        float scaleGreenVal = mapValues.remapValues(meterVal, -80.0f, 10.0f, 1.0f, 0.0f);
        float scaleBlueVal = mapValues.remapValues(meterVal, -80.0f, 10.0f, 1.0f, 0.0f);
        var colorRender = gameObject.GetComponent<Renderer>();
        newColor = new Color(scaleRedVal, scaleGreenVal, scaleBlueVal, 1.0f);
        colorRender.material.SetColor("_Color", newColor);

    }

}
