using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndDrop : MonoBehaviour
{
    GameObject grabbedObject;
    private float grabbedObjectSize;

    GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;

        if (Physics.Linecast(position, target, out raycastHit))
        {
            return raycastHit.collider.gameObject;
        }
        return null;
    }


    void tryGrabObject(GameObject grabObject)
    {
        if (grabbedObject == null)
            return;         // if it's nothing you can't grab it.

        grabbedObject = grabObject;
        // Renderer objectRenderer = grabbedObject.GetComponent<Renderer>();
        // grabbedObjectSize = objectRenderer.bounds.size.magnitude;
        grabbedObjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude;
    }

    void dropObject()
    {
        if (grabbedObject == null)
            return;     // if it's null do nothing

        grabbedObject = null;

    }

    // Update is called once per frame
    void Update()
    {

        /**
         * On right click, if no object grabbed, grab it.
         * If object is grabbed, drop it.
         */
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (grabbedObject == null)
                tryGrabObject(GetMouseHoverObject(10));
            else
                dropObject();
        }

        /**
         * If you have grabbed an object, place it in front of you,
         * extended forward by grabbedObjectSize.
         */
        if (grabbedObject != null)
        {
            Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize;
            grabbedObject.transform.position = newPosition;
        }
    }
}
