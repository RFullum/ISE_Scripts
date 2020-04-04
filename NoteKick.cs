using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Gets State from sequencerBlock
 */
public class NoteKick : MonoBehaviour
{

    private string currentNote;


    // Start is called before the first frame update
    void Start()
    {
        /**
         * Checks BPM for current sequencer beat division
         * gets note from sequencer cube stored in beat division index
         */
        int countIndex = BPM.sixteenthCountFull;
        currentNote = SequenceKick.patternKick[countIndex % 16];
    }

    // getter for private variable currentNote
    public string getNote()
    {
        string noteState = currentNote;

        return noteState;
    }
}
