using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InteractQuestTask : QuestTask
{
    private int currentQuantity;
    private List<Interactable> interactables;

    void Awake()
    {
        interactables = transform.GetComponentsInChildren<Interactable>().ToList();
        foreach (Interactable interactable in interactables)
        {
            interactable.onInteract += Progress;
            interactable.InteractableCollider.enabled = false;
        }
    }

    public override void Activate()
    {
        base.Activate();
        foreach (Interactable interactable in interactables)
        {
            interactable.InteractableCollider.enabled = true;
        }
    }

    public override void Progress()
    {
        currentQuantity++;
        base.Progress();
    }

    private void Update()
    {
        if (!active) return;
        if (currentQuantity == interactables.Count)
        {
            Complete();
        }
    }

    public override string GetObjectiveText()
    {
        return objective + $" {currentQuantity}/{interactables.Count}";
    }

}