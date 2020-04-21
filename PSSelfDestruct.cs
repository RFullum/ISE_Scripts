using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSSelfDestruct : MonoBehaviour
{
    private float lifeTime = 0.0f;
    private float selfDestruct = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime > selfDestruct)
        {
            Destroy(gameObject);
        }
        lifeTime += Time.deltaTime;
    }
}
