using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Gets State from sequencerBlock
 */
public class NoteSnare : MonoBehaviour
{
    private string currentNote;


    void Start()
    {
        /**
         * Checks BPM for current sequencer beat division
         * gets note from sequencer cube stored in beat division index
         */
        int countIndex = BPM.sixteenthCountFull;
        currentNote = SequenceSnare.patternSnare[countIndex % 16];

    }

    // getter for private variable currentNote
    public string getNote()
    {
        string noteState = currentNote;

        return noteState;
    }
}
