using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerPerc : MonoBehaviour
{
    // When sphere hits cube, destroy sphere
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PercCube")
            Destroy(gameObject);
    }
}
