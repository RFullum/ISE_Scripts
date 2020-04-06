using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Gets meter value from Wwise Subs Aux Bus
 */
public class LowMidsMeterRTPC : MonoBehaviour
{
    // Get PlayingID
    uint playingID = (uint)AkQueryRTPCValue.RTPCValue_PlayingID;

    // Instantiate meterValue variable
    public static float meterValue;

    // Game Object
    [SerializeField] GameObject obj;



    void Update()
    {
        updateMeter();
    }

    void updateMeter()
    {
        int type = 1;
        AkSoundEngine.GetRTPCValue("LowMidsRTPC", obj, playingID, out meterValue, ref type);
    }
}
