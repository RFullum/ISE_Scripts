using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Changes color of sequencer block depending on if it's active or inactive
 */
public class SequencerBlockColorKick : MonoBehaviour
{
    // Declare color values
    Color defaultColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
    Color activeColor = new Color(1.0f, 0.92f, 0.016f, 1.0f);

    // Used to convert cube name to int by slicing off "_SequenceCube" from name
    private string nameSlice = "_SequenceCube";


    void Start()
    {
        // Initializes sequencer blocks to defaultColor
        var colorRender = gameObject.GetComponent<Renderer>();
        colorRender.material.SetColor("_Color", defaultColor);
    }
    /*
    void Update()
    {
        // Derives patternIndex by slicing off leading name digits and converting to int
        string blockName = gameObject.name;
        string blockIndex = blockName.Replace(nameSlice, "");
        int patternIndex = System.Convert.ToInt32(blockIndex);

        /**
         * Toggles between defaultColor and activeColor:
         * Gets bool stored in array from SequenceKick script
         * When cube is inactive (false) - defaultColor
         * When cube is active (true) - activeColor
         */
         /*
        if (SequenceKick.pattern[patternIndex] == false)
        {
            var colorRender = gameObject.GetComponent<Renderer>();
            colorRender.material.SetColor("_Color", defaultColor);
        }
        else if (SequenceKick.pattern[patternIndex] == true)
        {
            var colorRender = gameObject.GetComponent<Renderer>();
            colorRender.material.SetColor("_Color", activeColor);
        }
    }
    */
}
