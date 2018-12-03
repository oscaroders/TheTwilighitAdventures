using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Open : PuzzleAction
{
    //TODO Make it work for all colliders in 2D
    private BoxCollider2D colliderBox;
    public bool activate;
    private void Start()
    {
        colliderBox = GetComponent<BoxCollider2D>();
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