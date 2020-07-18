using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DestinationQuestTask : QuestTask
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!active) return;

        Complete();
    }
}