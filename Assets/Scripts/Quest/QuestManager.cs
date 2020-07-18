using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<Quest> initQuests;
    [SerializeField] private QuestUI questUI;
    
    private Queue<Quest> quests;
    public QuestUI UI
    {
        get
        {
            return questUI;
        }
    }

    public static QuestManager instance { get; private set; }
    void Awake()
    {
        instance = this;
        quests = new Queue<Quest>();
        initQuests.ForEach(quests.Enqueue);
    }
    
    public delegate void OnQuestDone(int remainingQuests);
    public OnQuestDone onQuestDone;

    void Start()
    {
        Begin();
    }
    
    public void Begin()
    {
        StartNextQuest();
    }

    private void StartNextQuest()
    {
        if (quests.Count == 0)
        {
            return;
        }
        Quest quest = quests.Dequeue();
        quest.onComplete += () =>
        {
            onQuestDone?.Invoke(quests.Count);
            StartNextQuest();
        };
        quest.Begin();
    }
}