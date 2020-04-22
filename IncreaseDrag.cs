using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Slows the player's fall during easter egg
 */
public class IncreaseDrag : MonoBehaviour
{
    private float dragAmt = 100.0f;
    private float dragMult = 1.0f;

    // Initializes gravity to real gravity
    void Start()
    {
        Physics.gravity = new Vector3(0.0f, -9.81f, 0.0f);
    }

    /*
     * Raises drag when below y = -5
     */
    void Update()
    {
        if (transform.position.y < -30000)
        {
            Physics.gravity = new Vector3(0.0f, -1.1f, 0.0f);
        }

    }
}
