using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassBlockTrigger : MonoBehaviour
{
    private int cubeNote;
    private int cubeSequencerPos;


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
    }


}
