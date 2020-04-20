using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * When you enter the trigger the background goes from skybox to all black
 */
public class SkyboxToBlack : MonoBehaviour
{
    
    // Initiates to skybox
    void Start()
    {
        Camera.main.clearFlags = CameraClearFlags.Skybox;
    }

    // Sets to solidcolor
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Camera.main.clearFlags = CameraClearFlags.SolidColor;
        }
        
    }
}
