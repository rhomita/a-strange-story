using UnityEngine;

public abstract class QuestTask : MonoBehaviour
{
    [SerializeField] protected string objectiveTextKey;

    public delegate void OnComplete();
    public OnComplete onComplete;
    
    public delegate void OnProgress();
    public OnProgress onProgress;
    
    public delegate void OnActivate();
    public OnActivate onActivate;

    protected bool active = false;

    public virtual void Complete()
    {
        Debug.Log("QuestTask :: Complete -> " + gameObject.name);
        onComplete?.Invoke();
        active = false;
    }

    public virtual void Progress()
    {
        Debug.Log("QuestTask :: Progress -> " + gameObject.name);
        UpdateTaskText();
        onProgress?.Invoke();
    }

    public virtual void Activate()
    {
        Debug.Log("QuestTask :: Activate: " + gameObject.name);
        UpdateTaskText();
        onActivate?.Invoke();
        active = true;
    }

    private void UpdateTaskText()
    {
        string text = GetObjectiveText();
        GameManager.instance.UI.SetTaskText(text);
    }

    public virtual string GetObjectiveText()
    {
        return Localization.GetText(objectiveTextKey);
    }
}