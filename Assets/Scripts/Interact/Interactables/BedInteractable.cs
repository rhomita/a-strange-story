using UnityEngine;

public class BedInteractable : Interactable
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