﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlipableObject : MonoBehaviour {

    public bool useParticlePresets;
    public bool isFlippable;
    internal bool original = true;
    
    internal Vector3 startPosition;
    internal Quaternion startRotation;
    internal Vector3 endPosition;
    internal Quaternion endRotation;

    internal FlipWorld axis;
    private GameObject collider;

    [Header("Flippable Particles")]
    public bool wantParticles = true;
    public GameObject particlePrefab;
    private GameObject particle;
    public Color particleColor;

    private PlayerInput input;
    internal PuzzleMovement puzzleMovement;
    public bool isInDown;

    private void Start()
    {
        axis = GetComponentInParent<FlipWorld>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
       
        input = FindObjectOfType<PlayerInput>();  

        if (gameObject.name.Contains("Remnent"))
        {
            original = false;
            if(spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
            }
            
            BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
            if(collider2D != null)
            {
                collider2D.isTrigger = true;
            }
            
            
        }

        SetStartPosition(transform.position, transform.rotation);
        
        if(axis != null)
        {
            SetEndPosition(FlipWorld.GetRelativePosition(axis.transform, startPosition), Quaternion.Inverse( transform.rotation));
        }

        if (isFlippable && original)
        {
            collider = Instantiate(gameObject,endPosition,endRotation,transform.parent);
            collider.name = "Remnent of " + name;
        }
        if (isFlippable && wantParticles &&particle == null )
        {
            particle = Instantiate(particlePrefab, transform);
            FlipObjectParticle temp = particle.GetComponent<FlipObjectParticle>();
            temp.ChangeColor(particleColor);
        }
    }
    private void Update()
    {
        if(axis != null)
        {
            if (transform.position.y > axis.transform.position.y)
            {
                isInDown = false;
            }
            else
            {
                isInDown = true;
            }
        }
       
    }
    public void SetEndPosition(Vector3 position, Quaternion rotation)
    {
        if(original)
        {
            endPosition = startPosition;
            endPosition.y = position.y;

            rotation = rotation * Quaternion.AngleAxis(180, Vector3.forward);

            endRotation = rotation;

            if (particle != null)
            {
                particle.transform.position = endPosition;
                particle.transform.rotation = endRotation;
            }
        } else
        {
            endPosition = startPosition;
            endPosition.y = position.y;
            endRotation = rotation;
        }
        
    }
    public void SetStartPosition(Vector3 position, Quaternion rotation)
    {
        if (original)
        {
            startPosition = position;
            startRotation = rotation;
        }
        else
        {
            startPosition = position;
            startRotation = rotation;
        }
    }
    public void GoToStart()
    {

        transform.position = startPosition;
        transform.rotation = startRotation;
    }
    public void GoToEnd()
    {
        transform.position = endPosition;
        transform.rotation = endRotation;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!original)
        {
            if(input.characterInside == "")
            {
                input.characterInside = collision.name;
                DisableFlipingForPlayer();
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!original)
        {
            if(input.characterInside == collision.name)
            {
                input.characterInside = "";
                EnableFlipingForPlayer();
            }

        }
    }
    public void DisableFlipingForPlayer()
    {
        input.canFlip = false;
        Debug.Log("Disable Flip for player");
    }
    public void EnableFlipingForPlayer()
    {
        input.canFlip = true;
        Debug.Log("Enable Flip for player");
    }

}
