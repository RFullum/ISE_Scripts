using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Sets the bass note decay time via RTPC
 */
public class BassDecay : MonoBehaviour
{
    MapValues mapValues = new MapValues();

    void Update()
    {
        bassDecay();
    }

    void bassDecay()
    {
        var ballPos = transform.position.x;
        float decayTime = mapValues.remapValues(ballPos, 100.0f, 111.0f, 0.0f, 100.0f);
        AkSoundEngine.SetRTPCValue("BassDecayTime", decayTime);
    }
}
