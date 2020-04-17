using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *Tells how long an object is alive to the last frame.
 */
public class TimeAlive : MonoBehaviour
{
    float elapsedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        Debug.Log(elapsedTime);
    }
}
