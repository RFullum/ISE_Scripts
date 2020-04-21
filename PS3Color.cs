using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Changes color of ParticleSystem3 based on player transform
 */
public class PS3Color : MonoBehaviour
{
    // Particle system and player variables
    private ParticleSystem ps;
    private GameObject player, player2;
    private float posX, posY, posZ, rotX, rotY, tester;

    MapValues mapValues = new MapValues();

    // RTPC Meter value variables
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

        // Gets position values from Player
        posX = player.transform.position.x;
        posY = player.transform.position.y;
        posZ = player.transform.position.z;

        // Gets rotation value from Player
        rotX = player2.transform.localEulerAngles.x;
        rotY = player.transform.localEulerAngles.y;

        float rVal = mapValues.remapValues(rotY, 0.0f, 360.0f, 0.0f, 1.0f);
        float gVal = mapValues.remapValues(rotX, 0.0f, 360.0f, 0.0f, 1.0f);
        float bVal = mapValues.remapValues(Mathf.Abs(posY) % 101.0f, 0.0f, 101.0f, 0.0f, 1.0f);

        var main = ps.main;
        main.startColor = new Color(rVal, gVal, bVal, 1.0f);

        float trailWidth = mapValues.remapValues(lowMeter, -48.0f, 0.0f, 3.0f, 10.0f);
        float lifeColor1 = mapValues.remapValues(hiMidMeter, -48.0f, 0.0f, 0.0f, 1.0f);
        float lifeColor2 = mapValues.remapValues(lowMeter, -48.0f, 0.0f, 0.76f, 0.12f);

        var trails = ps.trails;
        trails.inheritParticleColor = true;
        trails.widthOverTrail = trailWidth;
        trails.colorOverLifetime = new Color(0.2f, lifeColor1, lifeColor2, 1.0f);
        trails.colorOverTrail = new Color(0.2f, lifeColor2, lifeColor1, 1.0f);
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
