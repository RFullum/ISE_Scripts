using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArpPlayerBall : MonoBehaviour
{
    private string pianoTag = "pianoTag";
    [SerializeField] GameObject spawnee;



    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.gameObject.tag == pianoTag)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    spawnArpBall();
                }
            }
        }
    }

    private void spawnArpBall()
    {
        float spawnX = 80.0f;
        float spawnY = 3.0f;
        float spawnZ = 60.0f;

        Instantiate(spawnee, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
    }
}
