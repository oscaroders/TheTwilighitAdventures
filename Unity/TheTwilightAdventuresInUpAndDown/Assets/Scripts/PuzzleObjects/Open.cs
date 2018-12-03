using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Open : PuzzleAction
{
    private Collider2D colliderBox;
    public bool activate;
    private void Start()
    {
        colliderBox = GetComponent<Collider2D>();
    }
    public override void OnActivation(bool activated)
    {
        activate = activated;
        if(activated)
            colliderBox.enabled = false;
        else
            colliderBox.enabled = true;
    }
}