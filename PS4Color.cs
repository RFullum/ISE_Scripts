using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Changes color of ParticleSystem3 based on player transform
 */
public class PS4Color : MonoBehaviour
{
    private ParticleSystem ps;
    private GameObject player, player2;


    MapValues mapValues = new MapValues();

    uint playingID = (uint)AkQueryRTPCValue.RTPCValue_PlayingID;
    public static float lowMeter, lowMidMeter, hiMidMeter, hiMeter;
    [SerializeField] GameObject obj;


    void Start()
    {
        // Sets GameObjects
        player = GameObject.Find("FPSController");
        player2 = GameObject.Find("FPSController/FirstPersonCharacter");

        ps = GetComponent<ParticleSystem>();

    }


    void Update()
    {
        getMeterValues();

        float rVal = mapValues.remapValues(lowMeter, -48.0f, 0.0f, 1.0f, 0.0f);
        float gVal = mapValues.remapValues(hiMidMeter, -48.0f, 0.0f, 1.0f, 0.0f);
        float bVal = mapValues.remapValues(hiMeter, -48.0f, 0.0f, 1.0f, 0.0f);
        //float alpha = mapValues.remapValues(lowMidMeter, -48.0f, 0.0f, 0.25f, 1.0f);

        var main = ps.main;
        main.startColor = new Color(rVal, gVal, bVal, 1.0f);

        //var trails = ps.trails;
        //trails.inheritParticleColor = true;
    }

    private void getMeterValues()
    {
        int type = 1;
        AkSoundEngine.GetRTPCValue("DRMLowMeter", obj, playingID, out lowMeter, ref type);
        AkSoundEngine.GetRTPCValue("DRMLowMidMeter", obj, playingID, out lowMidMeter, ref type);
        AkSoundEngine.GetRTPCValue("DRMHiMidMeter", obj, playingID, out hiMidMeter, ref type);
        AkSoundEngine.GetRTPCValue("DRMHiMeter", obj, playingID, out hiMeter, ref type);
    }
}
