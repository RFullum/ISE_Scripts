using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Drops cylinder and moves it randomly inside BassLPF box to bounce
 * LPF Ball around to constantly change RTPC vals
 */
public class BassLPFCylChaos : MonoBehaviour
{
    private Vector3 startPos, targetPos;
    private bool isMoving, activated;
    [SerializeField] float speed;

    /**
     * Initiates useGravity to false
     * Sets start position
     */
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        activated = false;
        startPos = gameObject.transform.position;
    }

    /**
     * Create a ray at center of mouse position (center screen)
     * if the raycast his the cylinder
     * and the player presses key "b", turn on the gravity
     * and start the cylinder movement
     * Racast object + key "x" destroys
     */
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    GetComponent<Rigidbody>().useGravity = true;
                    activated = true;
                }

                if (Input.GetKeyDown(KeyCode.X))
                {
                    Destroy(gameObject);
                }
            }
        }

        if (activated == true)
        {
            float step = speed * Time.deltaTime;
            moveToTarget();

            if (isMoving == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            }
        }
    }

    /**
     * Randomly sets X and Z values for new position movement
     * Sets isMoving to true
     */
    private void moveToTarget()
    {
        targetPos = new Vector3(Random.Range(startPos.x - 5.0f, startPos.x + 5.0f), gameObject.transform.position.y, Random.Range(startPos.z - 5.0f, startPos.z + 5.0f)); ;
        isMoving = true;
    }

}
