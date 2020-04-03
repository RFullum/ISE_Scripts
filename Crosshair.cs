using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * GUI crosshair on screen
 */
public class Crosshair : MonoBehaviour
{
    // Puts a small rectangle center screen so you know what you're looking at
    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 20, 20), "");
    }
}
