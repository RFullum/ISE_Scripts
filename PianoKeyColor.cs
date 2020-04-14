using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Colors natural keys white and sharp/flat keys black
 */
public class PianoKeyColor : MonoBehaviour
{
    Color naturalColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    Color sharpColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        var colorRenderer = gameObject.GetComponent<Renderer>();

        if (gameObject.name.Contains("sh"))
        {
            colorRenderer.material.SetColor("_Color", sharpColor);
        }
        else
        {
            colorRenderer.material.SetColor("_Color", naturalColor);
        }
            
    }
}
