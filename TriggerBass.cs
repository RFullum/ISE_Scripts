using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBass : MonoBehaviour
{
    //[SerializeField] string wwiseEvent;

    private string wwiseEvent;
    private string ballTag = "bassSeq";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ballTag)
        {
            //wwiseEvent = gameObject.name.Replace("(Clone)", "");
            wwiseEvent = collision.gameObject.name.Replace("(Clone)", "");
            AkSoundEngine.PostEvent(wwiseEvent, gameObject);
            Destroy(collision.gameObject);
        }

    }
}
