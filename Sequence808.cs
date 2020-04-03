﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Creates a set of 16 sequencer Cubes. Cubes can be activated or deactivated, and
 * determine the note triggered by that Cube in the sequence.
 * 
 * Creates an array of cubes, an array of bools that say whether that cube is on/off,
 * and an array of strings that stores the name of the state.
 * Used as a reference for the other scripts that need this data.
 */
public class Sequence808 : MonoBehaviour
{
    // Tag allows you to activate and deactivate sequencer blocks
    [SerializeField] private string beatTag = "beatToggle";

    // 1 bar = 16th notes, from BPM
    private int sequenceLength = 16;

    public static bool[] pattern = new bool[16];        // Tracks active/inactive sequenceBlocks
    public GameObject sequenceCube;                     // Prefab cube (Spawn non-prefab cubes somehow?)
    GameObject[] sequenceBlocks = new GameObject[16];   // Array for sequenceCube instances

    // Declare Note Values
    private string[] notes = new string[13] { "C0", "CshDb0", "D0", "DshEb0", "E0", "F0", "FshGb0", "G0", "GshAb0", "A1", "AshBb1", "B1", "C1" };
    public static string[] patternNote = new string[16];
    private int notePicker = 0;

    /**
     * Used to name block instances and then convert cube name to int
     * by slicing off "_SequenceCube" from name
     */
    private string nameSlice = "_SequenceCube";


    void Start()
    {
        /**
         * initialize sequencer: all blocks inactive (false)
         * create sixteen sequencer blocks offset from parent object
         * names blocks index number i + "_SequenceCube"
         * updates tag
         */
        for (int i = 0; i < sequenceLength; i++)
        {
            pattern[i] = false;
  
            GameObject sequenceBlockInstance = Instantiate(sequenceCube);
            sequenceBlockInstance.transform.position = this.transform.position;
            sequenceBlockInstance.transform.parent = this.transform;
            sequenceBlockInstance.name = i + nameSlice;
            sequenceBlockInstance.transform.position = new Vector3(20.0f + i, 0.5f, 0.0f + (i * 0.1f));
            sequenceBlockInstance.tag = beatTag;

            /**
             * Initializes all notes to "C0" so there's a valid state name.
             */
            patternNote[i] = "C0";
            

            /**
             * Places child cubes into GameObject array sequenceBlocks
             */
            sequenceBlocks[i] = sequenceCube;
        }
    }


    void Update()
    {
        // Create a ray at center of mouse position (center screen)
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        /**
         * If the object is tagged as a beatTag, pressing "b" will toggle
         * the bool of the pattern true/false.
         * True: activates the pattern position
         * False: deactivates the pattern position 
         * Pressing "n" will select the note, 13 semitones from C0 to C1
         */
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.gameObject.tag == beatTag)
            {
                // Activate/deactivate sequencerCube
                if (Input.GetKeyDown(KeyCode.B))
                {
                    /*
                     * derives pattern and sequenceBlock index from child object names:
                     * gets name of object. Strips leading number as char. Converts
                     * char to int.
                     */
                    string blockName = hit.collider.gameObject.name;
                    string blockIndex = blockName.Replace(nameSlice, "");
                    int patternIndex = System.Convert.ToInt32(blockIndex);

                    // flips bool at index
                    pattern[patternIndex] = !pattern[patternIndex];
                }

                /**
                 * Scroll through notes C0 through C1:
                 * When "n" is pressed, increment notePicker, wrap to 13
                 * Set selectedNote to Note State string at index notePicker
                 * Strip sequencerBlock number from block instance name
                 * store the selectedNote to the patternNote using block number as index
                 */
                if (Input.GetKeyDown(KeyCode.N))
                {
                    notePicker++;
                    notePicker %= 13;
                    string selectedNote = notes[notePicker];

                    string blockName = hit.collider.gameObject.name;
                    string blockIndex = blockName.Replace(nameSlice, "");
                    int patternIndex = System.Convert.ToInt32(blockIndex);

                    patternNote[patternIndex] = selectedNote;

                }
            }
        }
    }

}
