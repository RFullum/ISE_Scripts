using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Changes color of sequencer block depending on if it's active or inactive,
 * open hat or closed hat
 */
public class SequencerBlockColorHat : MonoBehaviour
{
    // Declare color values
    Color defaultColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
    Color activeColor = new Color(1.0f, 0.92f, 0.016f, 1.0f);
    Color openColor = new Color(0.988f, 0.466f, 0.012f, 1.0f);

    // Used to convert cube name to int by slicing off "_SequenceCube" from name
    private string nameSlice = "_SequenceHatCube";


    void Start()
    {
        // Initializes sequencer blocks to defaultColor
        var colorRender = gameObject.GetComponent<Renderer>();
        colorRender.material.SetColor("_Color", defaultColor);
    }

    // Update is called once per frame
    void Update()
    {
        // Derives patternIndex by slicing off leading name digits and converting to int
        string blockName = gameObject.name;
        string blockIndex = blockName.Replace(nameSlice, "");
        int patternIndex = System.Convert.ToInt32(blockIndex);

        /**
         * Toggles between defaultColor and activeColor:
         * Gets bool stored in array from SequenceSnare script
         * When cube is inactive (false) - defaultColor
         * When cube is active (true) - activeColor or openColor, depending on
         * the open/close switch
         * 
         */

        if (SequenceHat.pattern[patternIndex] == false)
        {
            var colorRender = gameObject.GetComponent<Renderer>();
            colorRender.material.SetColor("_Color", defaultColor);
        }
        else if (SequenceHat.pattern[patternIndex] == true)
        {
            if (SequenceHat.patternOpenClose[patternIndex] == "Closed")
            {
                var colorRender = gameObject.GetComponent<Renderer>();
                colorRender.material.SetColor("_Color", activeColor);
            }
            else if (SequenceHat.patternOpenClose[patternIndex] == "Open")
            {
                var colorRender = gameObject.GetComponent<Renderer>();
                colorRender.material.SetColor("_Color", openColor);
            }
        }
    }
}
