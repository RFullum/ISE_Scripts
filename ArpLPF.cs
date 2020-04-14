using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArpLPF : MonoBehaviour
{
    MapValues mapValues = new MapValues();


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arpLPFParams();
    }

    void arpLPFParams()
    {
        var ballX = transform.position.x;
        var ballZ = transform.position.z;

        float filtFreq = mapValues.remapValues(ballX, 95.5f, 104.5f, 0.0f, 100.0f);
        float filtRes = mapValues.remapValues(ballZ, 35.5f, 26.5f, 0.0f, 100.0f);

        AkSoundEngine.SetRTPCValue("ArpLPFEnv", filtFreq);
        AkSoundEngine.SetRTPCValue("ArpLPFRes", filtRes);
    }
}
