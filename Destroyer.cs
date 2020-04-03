using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Destroys sphere on collision
 */
public class Destroyer : MonoBehaviour
{
    // When sphere hits cube, destroy sphere
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "808Cube")
            Destroy(gameObject);
    }
}
