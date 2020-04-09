using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBass : MonoBehaviour
{
    private string wwiseEvent;
    private string ballTag = "bassSeq";

    /**
     * When ball collides with bass platform, it uses the ball's name to
     * assign the string to the wwiseEvent, then calls the event, and then
     * destroys ball.
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ballTag)
        {
            wwiseEvent = collision.gameObject.name.Replace("(Clone)", "");
            AkSoundEngine.PostEvent(wwiseEvent, gameObject);
            Destroy(collision.gameObject);
        }

    }
}
