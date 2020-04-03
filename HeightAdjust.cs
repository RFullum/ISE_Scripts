using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Adjust object height using values from GetRTPCSong script
 */
public class HeightAdjust : MonoBehaviour
{
    // To scale meter values to adjust height
    private float scaleVal = 20.0f;

    void Start()
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);   // Initial scale
    }
   

    /**
     * From GetRTPCSong script, get meterValue & transpose by 100 to positive
     * values. Scales meterVal by scaleVal. Changes transform scale's y value
     * by scaleMeterVal to change height of object.
     */
    void Update()
    {
        float meterVal = GetRTPCSong.meterValue + 100.0f;
        float scaleMeterVal = meterVal / scaleVal;
        transform.localScale = new Vector3(1.0f, scaleMeterVal, 1.0f);
    }
}
