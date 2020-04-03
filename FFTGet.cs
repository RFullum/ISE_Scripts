using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFTGet : MonoBehaviour
{
    AudioSource audioSource;
    public static float[] samples = new float[512];


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(audioSource);
    }
}