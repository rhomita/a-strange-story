using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    public delegate void OnInteract();
    public OnInteract onInteract;

    public Collider InteractableCollider { get; private set; }
    
    void Awake()
    {
        InteractableCollider = transform.GetComponent<Collider>();
    }
    
    public void Interact()
    {
        onInteract?.Invoke();
    }
}