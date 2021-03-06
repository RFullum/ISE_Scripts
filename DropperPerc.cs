﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * spawns sphere to drop
 */
public class DropperPerc : MonoBehaviour
{
    // Object to be spawned
    public GameObject spawnee;


    void Update()
    {
        /**
         * On the sequencer beat, if sequencer cube is active, spawn sphere
         */
        if (BPM.sixteenthBeatFull)
        {
            int beatCount = BPM.sixteenthCountFull % 16;

            if (SequencePerc.pattern[beatCount] == true)
            {
                spawnSequencer();
            }
        }

    }

    /**
     * Sphere spawner
     */
    public void spawnSequencer()
    {
        float spawnX = 10.0f;
        float spawnY = 10.0f;
        float spawnZ = -20.0f;

        Instantiate(spawnee, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
    }
}
