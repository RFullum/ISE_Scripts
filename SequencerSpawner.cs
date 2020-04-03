using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SequencerSpawner : MonoBehaviour
{
    public GameObject spawnee;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnSequencer", 0);
        
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */

    public void SpawnSequencer()
    {
        float spawnX = 0.0f;
        float spawnY = 0.5f;
        float spawnZ = 10.0f;

        int seqLength = 16;
        int numDrums = 6;


        for (int i=0; i<numDrums; i++)
        {
            for (int j=0; j<seqLength; j++)
            {
                spawnX = (j % seqLength) + 10.0f;

                Instantiate(spawnee, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
                
            }

            spawnY += 1.0f;

            
        }
    }
}
