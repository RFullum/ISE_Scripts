using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Changes color of ParticleSystem3 based on player transform
 */
public class PS3Color : MonoBehaviour
{
    private ParticleSystem ps;
    private GameObject player, player2;
    private float posX, posY, posZ, rotX, rotY, tester;

    MapValues mapValues = new MapValues();


    void Start()
    {
        // Sets GameObjects
        player = GameObject.Find("FPSController");
        player2 = GameObject.Find("FPSController/FirstPersonCharacter");

        ps = GetComponent<ParticleSystem>();

    }


    void Update()
    {
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

        var trails = ps.trails;
        trails.inheritParticleColor = true;
    }
}
