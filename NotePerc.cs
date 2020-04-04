using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Gets State from sequencerBlock
 */
public class NotePerc : MonoBehaviour
{
    private string currentNote;


    void Start()
    {
        /**
         * Checks BPM for current sequencer beat division
         * gets note from sequencer cube stored in beat division index
         */
        int countIndex = BPM.sixteenthCountFull;
        currentNote = SequencePerc.patternPerc[countIndex % 16];
    }

    // getter for private variable currentNote
    public string getNote()
    {
        string noteState = currentNote;

        return noteState;
    }
}
