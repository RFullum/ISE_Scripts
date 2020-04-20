using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Sets organ fx send amount
 */
public class OrganFXSendAmt : MonoBehaviour
{
    MapValues mapValues = new MapValues();



    // Update is called once per frame
    void Update()
    {
        organFXSend();
    }

    private void organFXSend()
    {
        var ballPos = transform.position.x;
        float sendAmt = mapValues.remapValues(ballPos, 60.0f, 70.0f, 0.0f, 100.0f);
        AkSoundEngine.SetRTPCValue("OrganFXSend", sendAmt);
    }
}
