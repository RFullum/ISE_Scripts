using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBassTriggerBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BassPlatform")
            Destroy(gameObject);
    }
}
