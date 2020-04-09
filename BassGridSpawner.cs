using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassGridSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawnee26;
    [SerializeField] GameObject spawnee17;

    // Prefab BassGrid26
    private float spawnX26 = 100.0f;
    private float spawnY26 = 0.125f;
    private float spawnZ26 = 12.5f;

    // Prefab BassGrid17
    private float spawnX17 = 108.0f;
    private float spawnY17 = 0.125f;
    private float spawnZ17 = 0.0f;

    // Grid grid lines in each direction
    private int numGridLines26 = 17;
    private int numGridLines17 = 26;


    void Start()
    {
        spawnGrid26();
        spawnGrid17();
    }


    private void spawnGrid26()
    {
        for (int i = 0; i < numGridLines26; i++)
        {
            var spawnPos = new Vector3(spawnX26 + i, spawnY26, spawnZ26);
            Instantiate(spawnee26, spawnPos, Quaternion.identity);
        }
    }

    private void spawnGrid17()
    {
        for (int i = 0; i < numGridLines17; i++)
        {
            var spawnPos = new Vector3(spawnX17, spawnY17, spawnZ17 + i);
            Instantiate(spawnee17, spawnPos, Quaternion.identity);
        }
    }

}
