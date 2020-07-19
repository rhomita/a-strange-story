using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public List<Interactable> interactables;

    void Update()
    {
        Interactable interactable = interactables.Count > 0 ? interactables[0] : null;
        
        if (Input.GetKeyDown(KeyCode.E) && interactable != null)
        {
            interactable.Interact();
            interactables.Remove(interactable);
        }

        string hintText = interactable != null ? interactable.GetHintText() : "";
        GameManager.instance.UI.SetHintText(hintText);
    }
    
    void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable == null) return;
        if (!interactable.IsActive) return;
        
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
