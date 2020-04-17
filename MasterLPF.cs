using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterLPF : MonoBehaviour
{
    private string bp = "Master_LPF_Bypass";
    private float bypassOn = 0.0f;
    private float bypassOff = 100.0f;
    private bool bypassToggle = true;   // true = bypassed; false = active;

    private float frequency, resonance;
    private string freq = "Master_LPF_Freq";
    private string res = "Master_LPF_Res";
    MapValues mapValues = new MapValues();

    /*
     * Initialize to bypass on
     */
    void Start()
    {
        AkSoundEngine.SetRTPCValue(bp, bypassOn);
    }

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Sets bypassToggle true and false
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    bypassToggle = !bypassToggle;
                }
            }
        }

        // turns bypass on and off
        if(bypassToggle == true)
        {
            AkSoundEngine.SetRTPCValue(bp, bypassOn);
        }
        else if (bypassToggle == false)
        {
            AkSoundEngine.SetRTPCValue(bp, bypassOff);
        }


        float posX = gameObject.transform.position.x;
        float posZ = gameObject.transform.position.z;

        frequency = mapValues.remapValues(posX, -26.0f, 147.0f, 0.0f, 100.0f);
        resonance = mapValues.remapValues(posZ, -99.9f, 99.0f, 0.0f, 100.0f);

        AkSoundEngine.SetRTPCValue(freq, frequency);
        AkSoundEngine.SetRTPCValue(res, resonance);
    }
}
