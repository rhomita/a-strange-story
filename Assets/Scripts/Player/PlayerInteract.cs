using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public List<Interactable> interactables;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactables.Count > 0)
        {
            Interactable interactable = interactables[0];
            interactable.Interact();
            interactables.Remove(interactable);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable == null) return;
        
        if (interactables.Contains(interactable)) return;
        interactables.Add(interactable);
    }

    void OnTriggerExit(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable == null) return;

        if (!interactables.Contains(interactable)) return;
        interactables.Remove(interactable);
    }
}
