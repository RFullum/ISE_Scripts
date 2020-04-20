using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEverything : MonoBehaviour
{
    /*
     * Initializes everything to not be destroyed.
     */
    void Start()
    {
        Singleton.Instance.destroyEverything = false;
    }


    /*
     * Sets Singleton's destroyEverything bool to true
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Singleton.Instance.destroyEverything = true;
        }
            
    }
}
