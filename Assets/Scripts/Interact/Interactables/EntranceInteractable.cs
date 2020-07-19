using System.Collections;
using UnityEngine;

public class EntranceInteractable : Interactable
{
    [SerializeField] private AudioClip onEnableClip;
    [SerializeField] private AudioClip onEnableClipTwo;

    private AudioSource onEnabledAudioSource;
    
    void Start()
    {
        onEnabledAudioSource = gameObject.AddComponent<AudioSource>();
        onEnabledAudioSource.loop = false;
        onEnabledAudioSource.volume = 0.8f;
        
        onInteract += _ =>
        {
            // TODO
        };
    }
    
    public override void Enable()
    {
        base.Enable();
        StartCoroutine(CloseDoorSound());
        StartCoroutine(ScreamSound());
    }
    
    IEnumerator CloseDoorSound()
    {
        yield return new WaitForSeconds(3);
        onEnabledAudioSource.PlayOneShot(onEnableClip);
    }
    
    IEnumerator ScreamSound()
    {
        yield return new WaitForSeconds(0.5f);
        onEnabledAudioSource.PlayOneShot(onEnableClipTwo);
    }
}