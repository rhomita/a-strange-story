using UnityEngine;

public abstract class QuestTask : MonoBehaviour
{
    [SerializeField] protected string objective;

    public delegate void OnComplete();
    public OnComplete onComplete;
    
    public delegate void OnProgress();
    public OnProgress onProgress;
    
    public delegate void OnActivate();
    public OnActivate onActivate;

    protected bool active = false;

    public virtual void Complete()
    {
        onComplete?.Invoke();
        active = false;
    }

    public virtual void Progress()
    {
        onProgress?.Invoke();
    }

    public virtual void Activate()
    {
        onActivate?.Invoke();
        active = true;
    }

    public virtual string GetObjectiveText()
    {
        return objective;
    }
}