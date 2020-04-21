using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS6Color : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        getMeterValues();

        float lowVal = mapValues.remapValues(lowMeter, -48.0f, -6.0f, 0.5f, 4.0f);
        float hiMidVal = mapValues.remapValues(hiMidMeter, -48.0f, 0.0f, 100.0f, 200.0f);
        float hiVal = mapValues.remapValues(hiMeter, -48.0f, 0.0f, 1.0f, 10.0f);
        float hiValColor = mapValues.remapValues(hiMeter, -48.0f, 0.0f, 0.4f, 0.12f);
        float lowMidVal = mapValues.remapValues(lowMidMeter, -48.0f, 0.0f, 1.0f, 50.0f);
        float lowMidColor = mapValues.remapValues(lowMidMeter, -48.0f, 0.0f, 0.3f, 0.76f);

        var main = ps.main;
        main.startColor = new Color(0.5f, hiValColor, lowMidColor, 1.0f);
        main.startSize = hiMidVal;
        main.simulationSpeed = lowMidVal;
        main.gravityModifier = hiVal;
        main.startSpeedMultiplier = lowVal;
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

