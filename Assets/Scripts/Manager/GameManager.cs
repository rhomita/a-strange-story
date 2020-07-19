using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameUI gameUi;

    private Transform playerCamera;

    public Transform Player
    {
        get
        {
            return player;
        }
    }
    
    public GameUI UI
    {
        get
        {
            return gameUi;
        }
    }
    
    #region Singleton
    public static GameManager instance { get; private set; }
    void Awake()
    {
        instance = this;
        player.gameObject.SetActive(false);
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
                Cinematic.instance.End();
            }
        };
        HideCursor();
        
        UI.SetHintText("");
        UI.SetSubtitleText("");
        UI.SetTaskText("");
        
        Cinematic.instance.Begin();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneLoader.Restart();
        }
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
