using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganCubeFlier : MonoBehaviour
{
    private bool activated, isMoving;
    private Vector3 startPos, targetPos;
    [SerializeField] float speed;

    /*
     * Initializes gravity on, activated and isMoving to false,
     * and startPos to current position
     */
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = true;
        activated = isMoving = false;
        startPos = gameObject.transform.position;
    }



    void Update()
    {
        float step = speed * Time.deltaTime;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        /*
         * When raycast over cube, and B is pressed, turn off gravity and
         * set activated to true
         */
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    GetComponent<Rigidbody>().useGravity = false;
                    activated = true;

                }
            }
        }

        if (activated == true)
        {
            if(isMoving == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            }

            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                isMoving = false;
            }

            if (isMoving == false)
            {
                moveToTarget();
            }

        }

    }

    /**
     * Randomly sets X and Z values for new position movement
     * Sets isMoving to true
     */
    private void moveToTarget()
    {
        float xTarget = Random.Range(-150.0f, 150.0f);
        float yTarget = Random.Range(2.0f, 50.0f);
        float zTarget = Random.Range(-150.0f, 150.0f);


        targetPos = new Vector3(xTarget, yTarget, zTarget);
        isMoving = true;
    }
}
