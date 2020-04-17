using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controls Attack and Decay time for Organ
 */
public class OrganADSR : MonoBehaviour
{
    private string attack = "Organ_Attack";
    private string decay = "Organ_Decay";

    MapValues mapValues = new MapValues();

    /*
     * Initialize attack and decay times
     */
    void Start()
    {
        AkSoundEngine.SetRTPCValue(attack, 0.0f);
        AkSoundEngine.SetRTPCValue(decay, 100.0f);
        
    }


    /*
     * Sets attack and decay time based on cube position
     */
    void Update()
    {
        float xPos = gameObject.transform.position.x;
        float zPos = gameObject.transform.position.z;

        float attackVal = mapValues.remapValues(xPos, -30.0f, 150.0f, 0.0f, 100.0f);
        float decayVal = mapValues.remapValues(zPos, -30.0f, 150.0f, 0.0f, 100.0f);

        AkSoundEngine.SetRTPCValue(attack, attackVal);
        AkSoundEngine.SetRTPCValue(decay, decayVal);
        
    }
}
