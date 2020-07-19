using UnityEngine;

public class DirtyClothesInteractable : Interactable
{
    void Start()
    {
        onInteract += _ =>
        {
            // TODO: Add sound
            Destroy(gameObject);
        };
    }
}