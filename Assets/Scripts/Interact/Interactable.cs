using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    public delegate void OnInteract(Interactable interactable);
    public OnInteract onInteract;

    private bool isActive = false;
    
    void Awake()
    {
        Disable();
    }

    public void Disable()
    {
        isActive = false;
    }

    public void Enable()
    {
        isActive = true;
    }
    
    public void Interact()
    {
        if (!isActive) return;
        onInteract?.Invoke(this);
    }
}