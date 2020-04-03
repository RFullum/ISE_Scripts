using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    public string wwiseEvent;

    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent(wwiseEvent, gameObject);

    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AkSoundEngine.PostEvent(wwiseEvent, gameObject);
        }
    }
    */
}
