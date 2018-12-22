using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

    [HideInInspector] public bool grounded;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    const float groundedRadius = .2f;

    private Rigidbody2D rigidBody2D;

    private UnityEvent OnLandEvent;

    internal float characterMult;
    [HideInInspector] public bool timeToFallDown;
    internal float yGroundPosition;


    [HideInInspector] public bool canInteract = true;
    private CharacterSettings characterSettings;
    private void Start()
    {
        characterSettings = FindObjectOfType<CharacterSettings>();
    }
    private void Awake() {
        rigidBody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
        if (rigidBody2D.gravityScale < 0)
            characterMult = -1;
        else
            characterMult = 1;
    }

    private void FixedUpdate() {

        bool wasGrounded = grounded;
        grounded = false;
        
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject != gameObject) {
                grounded = true;
                rigidBody2D.gravityScale = characterSettings.groundGravityScale * characterMult;
                yGroundPosition = transform.position.y;
                if (!wasGrounded)
                {
                    timeToFallDown = false;
                    canInteract = true;
                    OnLandEvent.Invoke();
                }
            }
        }
        
    }
}
