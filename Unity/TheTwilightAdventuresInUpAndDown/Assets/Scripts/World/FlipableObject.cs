using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ParticleSystem))]
public class FlipableObject : MonoBehaviour {

    internal bool original = true;
    public bool isFlippable;
    internal Vector3 startPosition;
    internal Quaternion startRotation;
    internal Vector3 endPosition;
    internal Quaternion endRotation;

    internal FlipWorld axis;


    private GameObject particle;


    public UnityEngine.Events.UnityEvent flipWorldTriggerDisable;
    public UnityEngine.Events.UnityEvent flipWorldTriggerEnable;

    private PlayerInput input;
    
    private void Start()
    {
        axis = GetComponentInParent<FlipWorld>();
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        ParticleSystem flipParticles = GetComponent<ParticleSystem>();
        input = FindObjectOfType<PlayerInput>();
        flipWorldTriggerDisable.AddListener(DisableFlipingForPlayer);
        flipWorldTriggerEnable.AddListener(EnableFlipingForPlayer);

        if (flipParticles != null)
        {
            var sh = flipParticles.shape;
            sh.shapeType = ParticleSystemShapeType.SpriteRenderer;
            sh.spriteRenderer = sprite;
            if (gameObject.name.Contains("Remnent"))
            {
                original = false;
                sprite.enabled = false;
                BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
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
            particle = Instantiate(this.gameObject,endPosition,endRotation,transform.parent);
            particle.name = "Remnent of" + name;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!original)
        {
            flipWorldTriggerDisable.Invoke();
            // Send Message so player cannot flipworld
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!original)
        {
            flipWorldTriggerEnable.Invoke();
            // Send Message so player can flipworld
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


    
}
