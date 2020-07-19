using UnityEngine;

public class DirtyClothesInteractable : Interactable
{
    void Start()
    {
        onInteract += _ =>
        {
            //TODO: Remove clothes
        };
    }
}