using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Gets meter value from Wwise Subs Aux Bus
 */
public class ElevatorSubsRTPC : MonoBehaviour
{
    // Get PlayingID
    uint playingID = (uint)AkQueryRTPCValue.RTPCValue_PlayingID;

    // Instantiate meterValue variable
    public static float meterValue;

    // Game Object
    [SerializeField] GameObject obj;

    
    private void Start()
    {
        meterValue = -90.0f;
    }
    


    void Update()
    {
        updateMeter();
    }

    void updateMeter()
    {
        int type = 1;
        AkSoundEngine.GetRTPCValue("SubsRTPC", obj, playingID, out meterValue, ref type);
    }
}
