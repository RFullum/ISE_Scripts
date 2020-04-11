using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassLPFChaosPoleMover : MonoBehaviour
{
    private bool activated;
    private Vector3 startPos;

    /**
     * initializes gravity to off, inactive, sets start position.
     */
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        activated = false;
        startPos = gameObject.transform.position;
    }


    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        /**
         * When raycast over pole + "b" pressed, turn on gravity,
         * activated is true
         * "x" destroys
         */
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    GetComponent<Rigidbody>().useGravity = true;
                    activated = true;
                    
                }

                if (Input.GetKeyDown(KeyCode.X))
                {
                    Destroy(gameObject);
                }
            }
        }

    }

    
}
