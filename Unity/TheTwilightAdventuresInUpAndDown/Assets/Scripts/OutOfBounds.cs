using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Zone))]
public class OutOfBounds : ActionObject
{
    public Animator animator;

    public PlayerInput input;
    public Transform eve, dodo;
    public Transform eveCheckpoint, dodoCheckpoint;
    public override void OnActivation(bool activated)
    {
        if (activated)
        {
            FadeIn();
            MoveToCheckpoint();
            FreezePlayer();
             
        }
    }

    void MoveToCheckpoint() {
        eve.position = eveCheckpoint.position;
        dodo.position = dodoCheckpoint.position;
    }

    void FadeIn() {
        animator.SetTrigger("FadeIn");
        Invoke("RetrunToStartInAnimator", 1f);
    }

    void RetrunToStartInAnimator() {
        animator.SetTrigger("Start");
        Invoke("UnFreezePlayer", 0.1f);
    }

    public void FreezePlayer() {
        input.enabled = false;
    }

    public void UnFreezePlayer() {
        input.enabled = true;
    }
}