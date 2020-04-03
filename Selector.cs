using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    // Make selectable objects tag "Selectable
    [SerializeField] private string selectableTag = "Selectable";

    // Choose materials
    [SerializeField] private Material highlightMaterial;
    //[SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    // Keeps track of selection.
    private Transform _selection;

    // Update is called once per frame
    void Update()
    {
        // Deselection/Selection Manager (Deselect)
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
                selectionRenderer.material = defaultMaterial;
        }


        // Create a ray at center of mouse position (center screen)
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // hit object
        // RaycastHit hit;

        // Determin selection
        // if ray crosses object hit, get hit's transform as selection
        if (Physics.Raycast(ray, out var hit))
        {
            var selection = hit.transform;

            if (selection.CompareTag(selectableTag))
            {
                _selection = selection;
            }
        }

        // Deselection/Selection Manager (Deselect)
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();

            if (selectionRenderer != null)
                selectionRenderer.material = highlightMaterial;
        }

    }
}
