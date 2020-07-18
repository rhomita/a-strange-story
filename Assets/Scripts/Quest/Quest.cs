using System;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] private Queue<QuestTask> tasks;
    [SerializeField] private Quest nextQuest;
    
    public void Begin()
    {
        GetTask();
    }

    private void GetTask()
    {
        if (tasks.Count == 0)
        {
            End();
            return;
        }
        QuestTask questTask = tasks.Dequeue();
        questTask.onComplete += GetTask;
        questTask.Activate();
    }

    void End()
    {
        if (nextQuest == null) return;
        nextQuest.Begin();
        Destroy(gameObject);
    }
}