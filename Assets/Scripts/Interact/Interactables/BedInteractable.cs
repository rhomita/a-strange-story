using UnityEngine;

public class BedInteractable : Interactable
{
    void Start()
    {
        onInteract += _ =>
        {
            Debug.Log("Add animation");
        };
    }
}