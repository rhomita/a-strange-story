using UnityEngine;

public class DirtyClothesInteractable : Interactable
{
    [SerializeField] private GameObject GFX;

    void Start()
    {
        onInteract += _ => { Destroy(GFX); };
    }
}