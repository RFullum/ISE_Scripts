using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Sets Bass LPF freq and resonance RTPC
 */
public class BassLPF : MonoBehaviour
{
    MapValues mapValues = new MapValues();


    void Update()
    {
        bassLPFParams();
    }

    void bassLPFParams()
    {
        var ballX = transform.position.x;
        var ballZ = transform.position.y;

        float filtFreq = mapValues.remapValues(ballX, 100.0f, 111.0f, 0.0f, 100.0f);
        float filtRes = mapValues.remapValues(ballZ, -35.0f, -47.0f, 0.0f, 100.0f);

        AkSoundEngine.SetRTPCValue("BassLPFEnv", filtFreq);
        AkSoundEngine.SetRTPCValue("BassLPFRes", filtRes);
    }
}
