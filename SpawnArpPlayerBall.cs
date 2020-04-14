using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArpPlayerBall : MonoBehaviour
{
    private string pianoTag = "pianoTag";
    [SerializeField] GameObject spawnee;
    [SerializeField] GameObject killBall;

    private float spawnX = 80.0f;
    private float spawnY = 3.0f;
    private float spawnZ = 60.0f;

    ArpSpawner arpSpawner = new ArpSpawner();
    private int arpSpeed = 0;

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.gameObject.tag == pianoTag)
            {
                // Spawns arpeggiator ball
                if (Input.GetKeyDown(KeyCode.B))
                {
                    spawnArpBall();
                }

                // Spawns arpeggiator note killer ball
                if (Input.GetKeyDown(KeyCode.X))
                {
                    spawnKillBall();
                }

                // Updates arpeggiator speed
                if (Input.GetKeyDown(KeyCode.N))
                {
                    arpSpeed++;
                    arpSpeed %= 3;
                    arpSpawner.beatDivisionChooser(arpSpeed);
                }
            }
        }
    }

    private void spawnArpBall()
    {
        Instantiate(spawnee, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
    }

    private void spawnKillBall()
    {
        Instantiate(killBall, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
    }
}
