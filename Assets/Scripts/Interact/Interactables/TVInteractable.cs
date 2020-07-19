using UnityEngine;

public class TVInteractable : Interactable
{
    [SerializeField] private TV tv;
    void Start()
    {
        onInteract += _ =>
        {
            tv.TurnOff();
        };
    }
    
    public override void Enable()
    {
        base.Enable();
        tv.TurnOn();
    }
}