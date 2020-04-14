using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Spawns a piano roll for the Arpegiator
 */
public class PianoRollSpawn : MonoBehaviour
{
    [SerializeField] GameObject pianoKey;

    private int numKeys = 25;

    private float spawnX = 90.0f;
    private float spawnY = 0.75f;
    private float spawnZ = 60.0f;

    private string[] keyNames = new string[25] {"C2", "Csh2", "D2", "Dsh2", "E2", "F2", "Fsh2", "G2",
        "Gsh2", "A2", "Ash2", "B2", "C3", "Csh3", "D3", "Dsh3", "E3", "F3", "Fsh3", "G3",
        "Gsh3", "A3", "Ash3", "B3", "C4"};

    void Start()
    {
        for (int i=0; i<numKeys; i++)
        {
            pianoKey.name = keyNames[i];

            Instantiate(pianoKey, new Vector3(spawnX + i, spawnY, spawnZ), Quaternion.identity);

        }
    }


}
