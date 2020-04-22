using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS7Color : MonoBehaviour
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

        var main = ps.main;
        var trails = ps.trails;

        float startSizeMult = mapValues.remapValues(lowMeter, -48.0f, 0.0f, 1.0f, 10.0f);
        main.startSizeMultiplier = startSizeMult;

        float lowColor = 0.0f;
        if (lowMeter < -12.0f)
        {
            lowColor = 0.0f;
        }
        else if (lowMeter >= -12.0f)
        {
            lowColor = 1.0f;
        }

        trails.colorOverLifetime = new Color(lowColor, 1.0f, 0.0f, 1.0f);
        trails.colorOverTrail = new Color(lowColor, 0.85f, 0.0f, 1.0f);

        float gravModMult = mapValues.remapValues(hiMidMeter, -48.0f, 0.0f, 0.25f, 3.0f);
        main.gravityModifierMultiplier = gravModMult;

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
