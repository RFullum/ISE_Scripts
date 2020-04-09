using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassGridSpawner : MonoBehaviour
{
    // Gets GameObjects
    [SerializeField] GameObject spawnee26;
    [SerializeField] GameObject spawnee17;
    [SerializeField] GameObject spawneeTriggerCube;

    // Prefab BassGrid26
    private float spawnX26 = 100.0f;
    private float spawnY26 = 0.125f;
    private float spawnZ26 = 12.5f;

    // Prefab BassGrid17
    private float spawnX17 = 108.0f;
    private float spawnY17 = 0.125f;
    private float spawnZ17 = 0.0f;

    // Prefab BassTriggerCube
    private float spawnXbassTrig = 100.5f;
    private float spawnYbassTrig = 0.125f;
    private float spawnZbassTrig = 0.5f;
    private string cubeName = "_bassTriggerCube_";

    // Grid grid lines in each direction
    private int numGridLines26 = 17;
    private int numGridLines17 = 26;

    // Call methods that spawn grid rails and trigger cubes
    void Start()
    {
        spawnGrid26();
        spawnGrid17();
        spawnGridBassTrig();
    }

    // Spawns grid rails length of 25 notes
    private void spawnGrid26()
    {
        for (int i = 0; i < numGridLines26; i++)
        {
            var spawnPos = new Vector3(spawnX26 + i, spawnY26, spawnZ26);
            Instantiate(spawnee26, spawnPos, Quaternion.identity);
        }
    }

    // Spawns gril rails length of 16 sequencer positions
    private void spawnGrid17()
    {
        for (int i = 0; i < numGridLines17; i++)
        {
            var spawnPos = new Vector3(spawnX17, spawnY17, spawnZ17 + i);
            Instantiate(spawnee17, spawnPos, Quaternion.identity);
        }
    }

    /**
     * Creates grid of 16 x 25 cubes to act as triggers for the bass sequencer
     * names each cube with leading and trailing grid coordinates for referencing
     * in other scripts.
     */
    private void spawnGridBassTrig()
    {
        for (int i = 0; i < numGridLines17 - 1; i++)
        {
            for (int j=0; j<numGridLines26 - 1; j++)
            {
                var spawnPos = new Vector3(spawnXbassTrig + j, spawnYbassTrig, spawnZbassTrig + i);
                GameObject bassGridBlock = Instantiate(spawneeTriggerCube, spawnPos, Quaternion.identity);
                bassGridBlock.name = i + cubeName + j;
            }
        }
    }
}
