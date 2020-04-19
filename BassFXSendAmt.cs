using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Sets bass effects send amount
 */
public class BassFXSendAmt : MonoBehaviour
{
    MapValues mapValues = new MapValues();

    void Update()
    {
        bassEffectsSend();
    }

    void bassEffectsSend()
    {
        var ballPos = transform.position.x;
        float sendAmt = mapValues.remapValues(ballPos, 100.5f, 110.5f, 0.0f, 100.0f);
        AkSoundEngine.SetRTPCValue("BassFXSendAmt", sendAmt);
    }
}
