using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

    [SerializeField] private bool airControl = false;
    [HideInInspector] public bool grounded;
    [Space]

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    const float groundedRadius = .2f;

    private Rigidbody2D rigidBody2D;

    private UnityEvent OnLandEvent;

    private float characterMult;
    [HideInInspector] public bool timeToFallDown;
    private float yGroundPosition;


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
        if (!grounded)
        {
            canInteract = false;

            if (Mathf.Abs(transform.position.y - yGroundPosition) >= characterSettings.jumpHeight)
            {
                timeToFallDown = true;
                Debug.Log("Time to fall down: " + timeToFallDown);
                rigidBody2D.velocity += Vector2.up * Mathf.Clamp(rigidBody2D.gravityScale, -1, 1) * Physics2D.gravity.y * (characterSettings.lowJumpMultiplier - 1) * Time.deltaTime;
            }
            rigidBody2D.gravityScale = characterSettings.airGravityScale * characterMult;
            if ((rigidBody2D.gravityScale > 0 && rigidBody2D.velocity.y < 0) || (rigidBody2D.gravityScale < 0 && rigidBody2D.velocity.y > 0))
            {
                rigidBody2D.velocity += Vector2.up * Mathf.Clamp(rigidBody2D.gravityScale, -1, 1) * Physics2D.gravity.y * (characterSettings.fallMultiplier - 1) * Time.deltaTime;
            }
            else if (((rigidBody2D.gravityScale > 0 && rigidBody2D.velocity.y > 0) || (rigidBody2D.gravityScale < 0 && rigidBody2D.velocity.y < 0)) && !Input.GetButton("Jump"))
            {
                rigidBody2D.velocity += Vector2.up * Mathf.Clamp(rigidBody2D.gravityScale, -1, 1) * Physics2D.gravity.y * (characterSettings.lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }
}
