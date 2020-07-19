using System.Collections;
using UnityEngine;

public class TelephoneInteractable : Interactable
{
    [SerializeField] private AudioClip onEnableClip;

    private AudioSource onEnabledAudioSource;
    
    void Start()
    {
        onEnabledAudioSource = gameObject.AddComponent<AudioSource>();
        onEnabledAudioSource.loop = false;
        onEnabledAudioSource.volume = 1f;
        onEnabledAudioSource.spatialBlend = 1f;
        onEnabledAudioSource.playOnAwake = false;
        onEnabledAudioSource.clip = onEnableClip;
        
        onInteract += _ =>
        {
            onEnabledAudioSource.Stop();
            StartCoroutine(HangOff());
        };
    }

    void Update()
    {
        if (!IsActive) return;
        if (!audioSource.isPlaying)
        {
            PlayClip();
        }
    }
    
    public override void Enable()
    {
        base.Enable();
        onEnabledAudioSource.Play();
    }

    IEnumerator HangOff()
    {
        yield return new WaitForSeconds(4.5f);
        audioSource.Stop();
    }
}