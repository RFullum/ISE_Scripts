﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassBlockTrigger : MonoBehaviour
{
    [SerializeField] GameObject spawnee;

    private int cubeNote;
    private int cubeSequencerPos;
    private string ballTag = "bassSeq";

    private float spawnX;
    private float spawnY = 10.0f;
    private float spawnZ;

    MapValues mapValues = new MapValues();



    void Start()
    {
        /**
         * Strips the leading number from the cube name to derive the
         * note to trigger, 0 - 24 for the 25 bass note samples in Wwise
         * and converts to int
         */
        string currentCubeNameNote = gameObject.name;
        string cubeNotePos = currentCubeNameNote.Substring(0, 2).Replace("_", "");
        cubeNote = System.Convert.ToInt32(cubeNotePos);

        /**
         * Strips the trailing number from the cube name to derive the
         * sequencer position, 0 - 15, for the 16 sequencer steps and
         * converts to int
         */
        string currentCubeNamePos = gameObject.name;
        string cubeSeqPos = currentCubeNamePos.Substring(currentCubeNamePos.Length - 2).Replace("_", "");
        cubeSequencerPos = System.Convert.ToInt32(cubeSeqPos);

        spawnPositionFinder();
    }

    private void spawnPositionFinder()
    {
        spawnX = mapValues.remapValues(cubeSequencerPos, 0.0f, 15.0f, 100.0f, 111.0f);
        spawnZ = mapValues.remapValues(cubeNote, 0.0f, 24.0f, -25.0f, -15.0f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ballTag)
        {
            if(BPM.sixteenthBeatFull)
            {
                int beatCount = BPM.sixteenthCountFull % 16;

                if (beatCount == cubeSequencerPos)
                {
                    spawnBall();
                }
            }
        }
    }

    private void spawnBall()
    {
        spawnee.name = wwiseEventName();
        Instantiate(spawnee, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
    }

    private string wwiseEventName()
    {
        string[] eventNames = new string[25] { "Bass1C1", "Bass1CshDb1", "Bass1D1", "Bass1DshEb1",
            "Bass1E1", "Bass1F1", "Bass1FshGb1", "Bass1G1", "Bass1GshAb1", "Bass1A1", "Bass1AshBb1",
            "Bass1B1", "Bass1C2", "Bass1CshDb2", "Bass1D2", "Bass1DshEb2", "Bass1E2", "Bass1F2",
            "Bass1FshGb2", "Bass1G2", "Bass1GshAb2", "Bass1A2", "Bass1AshBb2", "Bass1B2", "Bass1C3"};

        return eventNames[cubeNote];
    }

}
