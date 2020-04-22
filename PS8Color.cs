using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS8Color : MonoBehaviour
{
    private ParticleSystem ps;
    private GameObject player, player2;


    MapValues mapValues = new MapValues();

    uint playingID = (uint)AkQueryRTPCValue.RTPCValue_PlayingID;
    public static float lowMeter, lowMidMeter, hiMidMeter, hiMeter;
    [SerializeField] GameObject obj;

    private float elapsedTime = 0.0f;


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
        elapsedTime += Time.deltaTime;

        float lowColor = 0.0f;

        if (lowMeter < -10.0f)
        {
            lowColor = 0.0f;
        }
        else if (lowMeter >= 10.0f)
        {
            lowColor = 1.0f;
        }

        float lowMidColor = mapValues.remapValues(lowMidMeter, -48.0f, 0.0f, 0.1f, 0.3f);

        var main = ps.main;
        main.startColor = new Color(0.0f, -lowColor, lowColor, 1.0f);
        main.gravityModifierMultiplier = elapsedTime % 10.0f;


        var trails = ps.trails;
        trails.colorOverLifetime = new Color(lowMidColor, lowMidColor + 0.2f, 0.1f, 0.1f);

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
