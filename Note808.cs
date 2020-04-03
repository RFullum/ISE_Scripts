using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Gets note from sequencerBlock
 */
public class Note808 : MonoBehaviour
{
    private string currentNote;

    void Start()
    {
        /**
         * Checks BPM for current sequencer beat division
         * gets note from sequencer cube stored in beat division index
         */
        int countIndex = BPM.sixteenthCountFull;
        currentNote = Sequence808.patternNote[countIndex % 16];
    }

    // getter for private variable currentNote
    public string getNote()
    {
        string noteState = currentNote;

        return noteState;
    }

}
