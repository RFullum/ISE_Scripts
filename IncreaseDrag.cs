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

    // Initializes drag to zero
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.drag = 0;
    }

    /*
     * Raises drag when below y = -5
     */
    void Update()
    {
        if (transform.position.y < -5.0f)
        {
            var rb = GetComponent<Rigidbody>();
            rb.drag = dragAmt * dragMult;
        }

        dragMult = (Time.deltaTime + dragMult) * 10.0f;
    }
}
