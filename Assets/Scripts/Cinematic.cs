using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
    [SerializeField] private GameObject washMachine;
    [SerializeField] private GameObject fridge;
    [SerializeField] private GameObject selfFridge;
    
    private Animator animator;
    private GameObject player;
    private Transform playerCamera;
    
    #region Singleton
    public static Cinematic instance { get; private set; }
    void Awake()
    {
        instance = this;
    }
    #endregion

    void Start()
    {
        washMachine.SetActive(false);
        selfFridge.SetActive(false);
    }
    
    public void Begin()
    {
        player = GameManager.instance.Player.gameObject;
        animator = transform.GetComponent<Animator>();
        animator.SetTrigger("Begin");
    }

    public void BeginEnd()
    {
        transform.gameObject.SetActive(false);
        player.SetActive(true);
        QuestManager.instance.Begin();
    }
    
    public void End()
    {
        player.SetActive(false);
        transform.gameObject.SetActive(true);
        washMachine.SetActive(true);
        // TODO: Refactor: Avoid getting components here.
        washMachine.GetComponent<Animator>().SetBool("talking", true);
        fridge.GetComponent<Animator>().SetBool("talking", true);
        animator.SetTrigger("End");
    }

    // TODO: This is ugly but there is no more time =(
    public void StopTalk()
    {
        washMachine.GetComponent<Animator>().SetBool("talking", false);
    }
    
    public void StartTalk()
    {
        washMachine.GetComponent<Animator>().SetBool("talking", true);
    }

    public void EnableSelfFridge()
    {
        selfFridge.SetActive(true);
    }

    public void ShowSubtitle(AnimationEvent _event)
    {
        AudioClip clip = (AudioClip) _event.objectReferenceParameter;
        GameManager.instance.AddSubtitle(clip);
    }

    public void GoToMenu()
    {
        GameManager.instance.GoToMenu();
    }
}
