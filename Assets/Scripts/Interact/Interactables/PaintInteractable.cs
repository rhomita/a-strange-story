using UnityEngine;

public class PaintInteractable : Interactable
{
    [SerializeField] private Animator animator;
    
    void Start()
    {
        onInteract += _ =>
        {
            animator.SetBool("show", true);
        };
    }
}