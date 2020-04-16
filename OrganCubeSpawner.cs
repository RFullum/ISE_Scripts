using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganCubeSpawner : MonoBehaviour
{
    private string organTag = "organ";
    [SerializeField] GameObject spawnee;

    private float spawnX = 65.0f;
    private float spawnY = 10.0f;
    private float spawnZ = -50.0f;


    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.gameObject.tag == organTag)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    spawnOrganCube();
                }
            }
        }
    }

    private void spawnOrganCube()
    {
        Instantiate(spawnee, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
    }
}
