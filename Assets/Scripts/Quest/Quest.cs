using System;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] private List<QuestTask> initTasks;
    
    private Queue<QuestTask> tasks;
    
    public delegate void OnComplete();
    public OnComplete onComplete;

    void Awake()
    {
        tasks = new Queue<QuestTask>();
        initTasks.ForEach(tasks.Enqueue);
    }
    
    public void Begin()
    {
        StartNextTask();
    }

    private void StartNextTask()
    {
        if (tasks.Count == 0)
        {
            onComplete?.Invoke();
            return;
        }
        Debug.Log("Quest :: StartNextTask -> " + gameObject.name);
        QuestTask questTask = tasks.Dequeue();
        questTask.onComplete += StartNextTask;
        questTask.Activate();
    }

}