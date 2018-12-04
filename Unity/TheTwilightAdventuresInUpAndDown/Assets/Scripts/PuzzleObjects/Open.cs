using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Open : PuzzleAction
{
    private Collider2D colliderBox;
    private Animator animata;
    public bool activate;
    private void Start()
    {
        colliderBox = GetComponent<Collider2D>();
        animata = GetComponent<Animator>();
    }
    public override void OnActivation(bool activated)
    {
        activate = activated;
        if (activated)
        {
            colliderBox.enabled = false;
            animata.Play("DoorOpen");
        }
        else
        {
            colliderBox.enabled = true;
            animata.Play("DoorClose");
        }
    }
}