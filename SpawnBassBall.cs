using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Spawns ball to grab and put into bass sequencer
 */
public class SpawnBassBall : MonoBehaviour
{
    [SerializeField] string bassTag = "bassSeq";
    [SerializeField] GameObject spawnee;

    /**
     * Create a ray at center of mouse position (center screen)
     * When raycast is over bassCylinder, and you press B,
     * it spawns a new bassBall to put in bass sequencer grid
     */
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.gameObject.tag == bassTag)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    spawnBassBall();
                }
            }
        }

    }

    private void spawnBassBall()
    {
        float spawnX = 98.0f;
        float spawnY = 2.0f;
        float spawnZ = 0.0f;

        Instantiate(spawnee, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
    }
}
