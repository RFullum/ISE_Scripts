using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArpPlatformColor : MonoBehaviour
{
    private float rColor, gColor, bColor;
    private float alphaUp = 1.0f;


    void Start()
    {
        generateRandomColor();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        generateRandomColor();
    }

    private void generateRandomColor()
    {
        rColor = Random.Range(0.0f, 1.0f);
        gColor = Random.Range(0.0f, 1.0f);
        bColor = Random.Range(0.0f, 1.0f);

        var colorRender = gameObject.GetComponent<Renderer>();
        colorRender.material.SetColor("_Color", new Color(rColor, gColor, bColor, alphaUp));
    }

}
