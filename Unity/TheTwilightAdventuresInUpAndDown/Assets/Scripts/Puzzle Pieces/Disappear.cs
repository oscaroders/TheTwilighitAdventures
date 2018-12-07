using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : ActionObject
{
    private Collider2D colliderBox;
    private SpriteRenderer spriteRenderer;
    public bool activate;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colliderBox = GetComponent<Collider2D>();
    }
    public override void OnActivation(bool activated)
    {
        activate = activated;
        if (activated)
        {
            spriteRenderer.enabled = false;
            colliderBox.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
            colliderBox.enabled = true;
        }
    }
}
