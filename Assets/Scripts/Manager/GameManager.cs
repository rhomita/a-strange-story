using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform player;

    public Transform Player
    {
        get
        {
            return player;
        }
    }
    
    #region Singleton
    public static GameManager instance { get; private set; }
    void Awake()
    {
        instance = this;
    }
    #endregion

    void Start()
    {
        QuestManager.instance.onQuestDone += remainingQuests =>
        {
            Debug.Log("Game manager :: Quests remaining: " + remainingQuests);
            if (remainingQuests == 0)
            {
                Debug.Log("Game manager :: Game finished.");    
            }
        };
        HideCursor();
    }
    
    void EnableCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
