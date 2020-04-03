using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Gets meter value from Wwise Master Audio Bus
 */
public class GetRTPCSong : MonoBehaviour
{
    // Get PlayingID
    uint playingID = (uint)AkQueryRTPCValue.RTPCValue_PlayingID;

    // Instantiate meterValue variable
    public static float meterValue;

    // Game Object
    [SerializeField] GameObject obj;


    void Update()
    {
        // Call updateMeter method
        updateMeter();
    }

    // Updates meterValue using RTPC value from Wwise
    void updateMeter()
    {
        int type = 1;
        AkSoundEngine.GetRTPCValue("meter", obj, playingID, out meterValue, ref type);
    }
}
