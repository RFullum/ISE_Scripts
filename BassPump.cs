using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassPump : MonoBehaviour
{
    private string pump = "BassPump";
    private float bypassed = 0.0f;
    private float activeFX = 100.0f;

    private bool bpToggle = true;

    private Color bpColor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
    private Color activeColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.SetRTPCValue(pump, bypassed);

        var renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", bpColor);
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var renderer = GetComponent<Renderer>();

        // Flips bpToggle bool
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    bpToggle = !bpToggle;
                }
            }
        }

        if (bpToggle == true)
        {
            AkSoundEngine.SetRTPCValue(pump, bypassed);
            renderer.material.SetColor("_Color", bpColor);
        }
        else if (bpToggle == false)
        {
            AkSoundEngine.SetRTPCValue(pump, activeFX);
            renderer.material.SetColor("_Color", activeColor);
        }
    }
}
