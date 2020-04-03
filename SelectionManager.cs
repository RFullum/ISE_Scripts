using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    //[SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    private Transform _selection;
    //private bool onOff = false;

    

    void Update()
    {
        /**
         * Deselection: Get renderer of selected, set material back to default,
         * and nullify selection.
         */
        if (_selection != null)     // && onOff == false
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        // Create a ray at center of mouse position (center screen)
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // hit object
        RaycastHit hit;

        /**
         * if the ray hits an object,
         * get the transform info from hit object,
         * get renderer of hit object.
         */
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;

            // Check that item is selectable.
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();

                // if renderer exists, set material to highlightMaterial
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }
                _selection = selection;     // Tracks what is selected.

                /**
                if (Input.GetMouseButton(0))
                {
                    if (onOff == false)
                    {
                        selectionRenderer.material = selectedMaterial;
                        onOff = true;
                    }
                    else if (onOff == true)
                    {
                        selectionRenderer.material = defaultMaterial;
                        onOff = false;
                    }
                    _selection = null;
                }
                */
                
            }

        }
    }
}
