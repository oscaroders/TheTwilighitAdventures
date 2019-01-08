using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Open : ActionObject
{
    private Collider2D colliderBox;
    private Animator animator;
    public bool activate;
    private void Start()
    {
        colliderBox = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }
    public override void OnActivation(bool activated)
    {
        activate = activated;
        if (activated)
        {
            colliderBox.enabled = false;
            animator.SetBool("IsOn", activated);
        }
        else
        {
            colliderBox.enabled = true;
            animator.SetBool("IsOn", activated);
        }
    }
}