using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllTheThings : MonoBehaviour
{
    void Update()
    {
        if (Singleton.Instance.destroyEverything == true)
        {
            Destroy(gameObject);
        }
        
    }
}
