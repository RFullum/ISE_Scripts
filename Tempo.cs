using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Gets transform.position.z from TempoBall object and updates beatsPerMinute in Singlton
 */
public class Tempo : MonoBehaviour
{
    // Instance of mapValues to remap ball position to tempo range.
    MapValues mapValues = new MapValues();

    private void Start()
    {
        Singleton.Instance.beatsPerMinute = 120.0f;
    }

    /**
     * finds transform position of ball on Z axis, maps to tempo range,
     * and updates beatsPerMinute
     */
    void Update()
    {
        var positionZ = transform.position.z;
        float newBPM = mapValues.remapValues(positionZ, 1.0f, 10.0f, 20.0f, 240.0f);
        Singleton.Instance.beatsPerMinute = newBPM;

    }

}
