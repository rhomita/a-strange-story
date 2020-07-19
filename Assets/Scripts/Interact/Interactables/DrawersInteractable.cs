using UnityEngine;

public class DrawersInteractable : Interactable
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