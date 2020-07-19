using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameUI gameUi;

    private Transform playerCamera;
    private AudioSource audioSource;

    public delegate void OnSubtitleDone();

    public Transform Player
    {
        get { return player; }
    }

    public GameUI UI
    {
        get { return gameUi; }
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
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.volume = 1f;
        audioSource.playOnAwake = false;

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

    public void AddSubtitle(AudioClip clip, string key = null, OnSubtitleDone onSubtitleDone = null)
    {
        if (clip == null) return;
        if (key == null)
        {
            key = clip.name;
        }
        string text = Localization.GetText(key);
        float seconds = clip.length;
        audioSource.PlayOneShot(clip);
        gameUi.SetSubtitleText(text, seconds);
        if (onSubtitleDone != null)
        {
            StartCoroutine(InvokeAfterSeconds(seconds, onSubtitleDone));
        }
    }

    private IEnumerator InvokeAfterSeconds(float seconds, OnSubtitleDone onSubtitleDone)
    {
        yield return new WaitForSeconds(seconds);
        onSubtitleDone?.Invoke();
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

    public void GoToMenu()
    {
        EnableCursor();
        SceneLoader.GoToSceneName("menu");
    }
}