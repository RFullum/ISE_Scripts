using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Remaps initValue from range x1 through x2,
 * to range y1 through y2.
 */
public class MapValues : MonoBehaviour
{
    public float remapValues(float initValue, float x1, float x2, float y1, float y2)
    {
        var m = (y2 - y1) / (x2 - x1);
        var c = y1 - (m * x1);

        return (m * initValue) + c;
    }

}
