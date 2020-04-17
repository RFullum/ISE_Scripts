using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassLPFChaosPoleMover : MonoBehaviour
{
    private bool activated, isMoving;
    private Vector3 startPos, targetPos;
    [SerializeField] float speed;
    [SerializeField] float degreesPerSec;
    [SerializeField] GameObject spawnee;

    /**
     * initializes gravity to off, inactive, sets start position.
     */
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        activated = false;
        isMoving = false;
        startPos = gameObject.transform.position;
    }

    
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        /**
         * When raycast over pole + "b" pressed, turn on gravity,
         * activated is true
         * "x" destroys
         */
         
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
                    spawnee.GetComponent<Rigidbody>().useGravity = false;
                    Instantiate(spawnee, startPos, Quaternion.identity);

                }

            }
        }

        if (activated == true)
        {
            float step = speed * Time.deltaTime;
            moveToTarget();

            if (isMoving == true)
            {
                float degRotation = degreesPerSec * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
                transform.Rotate(degRotation, degRotation, degRotation, Space.Self);
            }
        }

    }

    /**
     * Randomly sets X and Z values for new position movement
     * Sets isMoving to true
     */
    private void moveToTarget()
    {
        targetPos = new Vector3(Random.Range(startPos.x - 2.0f, startPos.x + 2.0f), gameObject.transform.position.y, Random.Range(startPos.z - 2.0f, startPos.z + 2.0f));
        isMoving = true;
    }



}
