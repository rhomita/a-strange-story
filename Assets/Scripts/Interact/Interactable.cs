using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Interactable : MonoBehaviour
{
    [SerializeField] private string hintTextKey;
    [SerializeField] private AudioClip audioClip;

    public delegate void OnInteract(Interactable interactable);

    public OnInteract onInteract;

    protected AudioSource audioSource;

    public bool IsActive { get; private set; }

    void Awake()
    {
        Disable();
        if (audioClip != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = false;
            audioSource.volume = 0.55f;
            audioSource.spatialBlend = 1;
        }
    }

    public virtual void Disable()
    {
        IsActive = false;
    }

    public virtual void Enable()
    {
        IsActive = true;
    }

    public void Interact()
    {
        if (!IsActive) return;
        if (audioClip != null)
        {
            PlayClip();
        }

        onInteract?.Invoke(this);
    }

    protected void PlayClip()
    {
        if (!IsActive) return;
        audioSource.PlayOneShot(audioClip);
    }

    public string GetHintText()
    {
        if (!IsActive) return null;
        string key = hintTextKey == "" ? "hint-generic" : hintTextKey;
        return Localization.GetText(key);
    }
}