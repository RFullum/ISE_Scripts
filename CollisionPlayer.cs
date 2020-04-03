using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    [SerializeField] string wwiseEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            AkSoundEngine.PostEvent(wwiseEvent, gameObject);
        }
    }
}
