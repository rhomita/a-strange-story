using UnityEngine;

public class PaintInteractable : Interactable
{
    void Start()
    {
        onInteract += _ =>
        {
            Debug.Log("Add animation");
        };
    }
}