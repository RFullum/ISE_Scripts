using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Spawns a bass chaos pole
 */
public class BassChaosPoleDropSpawn : MonoBehaviour
{
    [SerializeField] GameObject spawnee;
    private float spawnX; // = 101.0f;
    private float spawnY = 10.0f;
    private float spawnZ; // = -36.5f;
    private float spawnOffset = 4.5f;

    private int spawnCount = 0;

    // Spawns first pole
    void Start()
    {
        for (int i=0; i < 3; i++)
        {
            spawnX = 101.0f + (spawnOffset * i);
            for(int j=0; j < 3; j++)
            {
                spawnZ = -36.5f + (-spawnOffset * i);
                spawnPole();
                spawnCount++;
            }
            
        }
    }


    public void spawnPole()
    {
        spawnee.name = "pole_" + spawnCount;
        Instantiate(spawnee, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
    }


}
