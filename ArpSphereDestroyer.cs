using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArpSphereDestroyer : MonoBehaviour
{
    [SerializeField] string wwiseEvent;
    private string switchType = "Arp";
    private string switchName;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ArpPlatform")
        {
            switchName = gameObject.name.Replace("(Clone)", "");
            AkSoundEngine.SetSwitch(switchType, switchName, gameObject);
            AkSoundEngine.PostEvent(wwiseEvent, gameObject);

            StartCoroutine("destroyer");
        }
    }

    IEnumerator destroyer()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        yield return null;

    }
}
