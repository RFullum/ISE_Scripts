using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controls the HPF params on the master bus
 */
public class MasterHPF : MonoBehaviour
{
    MapValues mapValues = new MapValues();

    // RTPC names
    private string bp = "Master_HPF_Bypass";
    private string freq = "MasterHPFFreq";
    private string res = "MasterHPFRes";

    private float bypassed = 0.0f;
    private float activeFilt = 100.0f;
    private bool bpToggle = true; // true = bypassed; false = active;

    private float frequency, resonance;

    Color bpColor = new Color(1.0f, 0.0f, 0.75f, 1.0f);
    Color activeColor = new Color(0.0f, 1.0f, 0.75f, 1.0f);


    // initialize to bypassed and sets color
    void Start()
    {
        AkSoundEngine.SetRTPCValue(bp, bypassed);

        var renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", bpColor);
    }


    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var renderer = GetComponent<Renderer>();

        // Sets bypassToggle true and false
        if (Physics.Raycast(ray, out var hit))
            if (hit.collider.gameObject == gameObject)
                if (Input.GetKeyDown(KeyCode.B))
                    bpToggle = !bpToggle;

        // turn bypass on/off
        if (bpToggle == true)
        {
            AkSoundEngine.SetRTPCValue(bp, bypassed);
            renderer.material.SetColor("_Color", bpColor);
        }
        else if (bpToggle == false)
        {
            AkSoundEngine.SetRTPCValue(bp, activeFilt);
            renderer.material.SetColor("_Color", activeColor);
        }

        // Map position to LPF parameters
        float posX = gameObject.transform.position.x;
        float posZ = gameObject.transform.position.z;

        frequency = mapValues.remapValues(posX, -26.0f, 147.0f, 0.0f, 100.0f);
        resonance = mapValues.remapValues(posZ, -99.9f, 99.0f, 0.0f, 100.0f);

        AkSoundEngine.SetRTPCValue(freq, frequency);
        AkSoundEngine.SetRTPCValue(res, resonance);
    }
}
