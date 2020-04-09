using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Create a ray at center of mouse position (center screen)
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            if(hit.collider.gameObject == gameObject)
            {
                GetComponent<Rigidbody>().useGravity = false;
                gameObject.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
            }
        }
    }

    private void OnMouseUp()
    {
        gameObject.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }

}
