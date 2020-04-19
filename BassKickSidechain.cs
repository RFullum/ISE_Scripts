using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassKickSidechain : MonoBehaviour
{
    uint playingID = (uint)AkQueryRTPCValue.RTPCValue_PlayingID;

    private float meterValue;

    [SerializeField] GameObject obj;


    // Update is called once per frame
    void Update()
    {
        updateSidechain();
    }

    void updateSidechain()
    {
        int type = 1;
        AkSoundEngine.GetRTPCValue("KickMeter", obj, playingID, out meterValue, ref type);
        AkSoundEngine.SetRTPCValue("BassKickSidechain", meterValue);
    }
}
