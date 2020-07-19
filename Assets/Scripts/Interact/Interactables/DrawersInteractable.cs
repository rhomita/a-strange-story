using UnityEngine;

public class DrawersInteractable : Interactable
{
    void Start()
    {
        onInteract += _ =>
        {
            Debug.Log("Add animation");
        };
    }
}