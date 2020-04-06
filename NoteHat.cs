using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Gets State from sequencerBlock
 */
public class NoteHat : MonoBehaviour
{
    private string currentNote;
    private string openClose;

    
    void Start()
    {
        /**
         * Checks BPM for current sequencer beat division
         * gets note from sequencer cube stored in beat division index
         */
        int countIndex = BPM.sixteenthCountFull;
        currentNote = SequenceHat.patternHat[countIndex % 16];
        openClose = SequenceHat.patternOpenClose[countIndex % 16];
    }

    // getter for private variable currentNote
    public string getNote()
    {
        string noteState = currentNote;

        return noteState;
    }

    public string getOpenClose()
    {
        string openCloseState = openClose;

        return openCloseState;
    }
}
