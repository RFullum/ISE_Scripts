using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TauntsTrigger : MonoBehaviour
{
    [SerializeField] string wwiseEvent;

    private void OnTriggerEnter(Collider other)
    {
        AkSoundEngine.PostEvent(wwiseEvent, gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        AkSoundEngine.PostEvent(wwiseEvent, gameObject);
    }
}
