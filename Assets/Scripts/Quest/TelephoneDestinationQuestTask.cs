using UnityEngine;

public class TelephoneDestinationQuestTask : DestinationQuestTask
{
    [SerializeField] private AudioClip onEnableClip;

    private AudioSource onEnabledAudioSource;

    void Start()
    {
        onEnabledAudioSource = gameObject.AddComponent<AudioSource>();
        onEnabledAudioSource.loop = true;
        onEnabledAudioSource.volume = 1f;
        onEnabledAudioSource.spatialBlend = 1f;
        onEnabledAudioSource.playOnAwake = false;
        onEnabledAudioSource.clip = onEnableClip;
    }
    
    public override void Activate()
    {
        base.Activate();
        onEnabledAudioSource.Play();
    }

    public override void Complete()
    {
        base.Complete();
        onEnabledAudioSource.Stop();
    }
}