using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * When Arp ball hits piano key, animates key and adds note to arpegiator
 */
public class PianoKeyCollisionNote : MonoBehaviour
{
    Color originalColor;
    Color highlightedColor = new Color(1.0f, 0.92f, 0.016f, 1.0f);
    [SerializeField] float degRotation = 10.0f;

    ArpSpawner arpSpawner = new ArpSpawner();

    /*
     * sets original color of piano key
     */
    private void Start()
    {
        originalColor = gameObject.GetComponent<Renderer>().material.color;
    }

    /*
     * When ball collides with key, switch to active color, rotate key,
     * destroy ball, and run coroutine that re-initializes key.
     */
    private void OnCollisionEnter(Collision collision)
    {
        var colorRenderer = GetComponent<Renderer>();
        colorRenderer.material.SetColor("_Color", highlightedColor);
        transform.Rotate(degRotation, 0.0f, 0.0f, Space.Self);
        Destroy(collision.gameObject);

        string note = gameObject.name;
        arpSpawner.addToArp(note);

        StartCoroutine("pianoUp");
    }

    /*
     * Reverses key rotation and color.
     */
    IEnumerator pianoUp()
    {
        yield return new WaitForSeconds(1);
        transform.Rotate(-degRotation, 0.0f, 0.0f, Space.Self);

        var colorRenderer = GetComponent<Renderer>();
        colorRenderer.material.SetColor("_Color", originalColor);

        yield return null;
    }
}
