using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTrack : MonoBehaviour
{
    [SerializeField] string wwiseEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AkSoundEngine.PostEvent(wwiseEvent, gameObject);
        }
    }
}
