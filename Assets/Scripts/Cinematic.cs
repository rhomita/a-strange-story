using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
    private Animator animator;
    private GameObject player;
    private Transform playerCamera;
    private AudioSource audioSource;
    
    #region Singleton
    public static Cinematic instance { get; private set; }
    void Awake()
    {
        instance = this;
    }
    #endregion

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.volume = 1f;
        audioSource.playOnAwake = false;
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
        animator.SetTrigger("End");
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
