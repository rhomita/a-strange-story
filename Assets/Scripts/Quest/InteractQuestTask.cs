using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InteractQuestTask : QuestTask
{
    [SerializeField] private List<Interactable> interactables;
    private int currentQuantity;

    void Start()
    {
        foreach (Interactable interactable in interactables)
        {
            interactable.onInteract += (Interactable _interactable) =>
            {
                _interactable.Disable();
                Progress();
            };
            interactable.Disable();
        }
    }

    public override void Activate()
    {
        base.Activate();
        foreach (Interactable interactable in interactables)
        {
            interactable.Enable();
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
        string text = base.GetObjectiveText();
        if (interactables.Count == 1) return text;
        return text + $" {currentQuantity}/{interactables.Count}";
    }

}