using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sets game object to black
public class PlaneColor : MonoBehaviour
{
    void Start()
    {
        Color initColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        var planeRenderer = gameObject.GetComponent<Renderer>();
        planeRenderer.material.SetColor("_Color", initColor);
        
    }

}
