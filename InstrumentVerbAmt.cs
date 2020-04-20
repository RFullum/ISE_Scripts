using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentVerbAmt : MonoBehaviour
{
    private float verbAmt, verbDecay;
    private float colorR, colorG;
    MapValues mapValues = new MapValues();

    /*
     * Updates instrument verb amount based on X position value
     * Updates instrument verb decay based on Z position value
     * Changes color based on X and Z positions
     */
    void Update()
    {
        var renderer = GetComponent<Renderer>();
        float xPos = gameObject.transform.position.x;
        float zPos = gameObject.transform.position.z;

        verbAmt = mapValues.remapValues(xPos, -26.0f, 147.0f, 0.0f, 100.0f);
        verbDecay = mapValues.remapValues(zPos, -99.0f, 99.0f, 0.0f, 100.0f);
        AkSoundEngine.SetRTPCValue("VerbSendAmt", verbAmt);
        AkSoundEngine.SetRTPCValue("VerbDecay", verbDecay);

        // X value changes Red value
        // Z value changes Green value
        colorR = mapValues.remapValues(verbAmt, 0.0f, 100.0f, 0.0f, 1.0f);
        colorG = mapValues.remapValues(verbDecay, 0.0f, 100.0f, 0.0f, 1.0f);
        renderer.material.SetColor("_Color", new Color(colorR, colorG, 1.0f, 1.0f));

        // Make it stop bouncing or rolling
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
            if (hit.collider.gameObject == gameObject)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    var rb = GetComponent<Rigidbody>();
                    rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
                }
            }
    }
}
