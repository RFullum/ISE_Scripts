using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArpChaosPoleDropper : MonoBehaviour
{
    [SerializeField] GameObject spawnee;
    private float spawnX = 96.0f;
    private float spawnY = 10.0f;
    private float spawnZ = 35.0f;
    private float spawnOffset = 4.0f;

    private int spawnCount = 0;


    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                spawnPole(spawnX + (spawnOffset * i), spawnY, spawnZ - (spawnOffset * j));
                spawnCount++;
            }

        }


    }

    public void spawnPole(float x, float y, float z)
    {
        spawnee.name = "arpPole_" + spawnCount;
        Instantiate(spawnee, new Vector3(x, y, z), Quaternion.identity);
    }


}
