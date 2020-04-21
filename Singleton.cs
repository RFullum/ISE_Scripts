using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Singleton Game Manager
 */
public class Singleton : MonoBehaviour
{
    private static Singleton _instance;

    public static Singleton Instance
    {
        get
        {
            return _instance;
        }
    }

    // Counts object collisions
    public float beatsPerMinute;
    public bool destroyEverything;
    public bool isFalling = false;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
