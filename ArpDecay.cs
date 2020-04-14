using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Sets the Arp note decay time via RTPC
 */
public class ArpDecay : MonoBehaviour
{
    MapValues mapValues = new MapValues();


    void Update()
    {
        arpDecay();
    }

    void arpDecay()
    {
        var ballPos = transform.position.x;
        float decayTime = mapValues.remapValues(ballPos, 95.5f, 104.5f, 0.0f, 100.0f);
        AkSoundEngine.SetRTPCValue("ArpDecayTime", decayTime);
    }
}
