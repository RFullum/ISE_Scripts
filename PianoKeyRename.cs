using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Strips "(Clone)" from name of piano key so the names match the switches
 */
public class PianoKeyRename : MonoBehaviour
{
    void Start()
    {
        gameObject.name = gameObject.name.Replace("(Clone)", "");
    }
}
