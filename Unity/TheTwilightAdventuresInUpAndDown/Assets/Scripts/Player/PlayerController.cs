using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

    [Header("Movment settings")]
    [Space]

    [Range(0, 100)] [SerializeField] internal float v_Max;
    [Space]
    [Range(0, 10)] [SerializeField] internal float dragGround;
    [Range(0, 10)] [SerializeField] internal float dragAir;
    [Range(0, 200)] [SerializeField] internal float accelerationGround;
    [Range(0, 200)] [SerializeField] internal float accelerationAir;
    [Space]
    [Range(0, 10)] [SerializeField] internal float sprintMultiplier;

    [Header("Jump Settings")]
    [Space]

    [Range(0, 20)] [SerializeField] internal float jumpSpeed = 10f;
    [Range(0, 10)] [SerializeField] private float fallMultiplier = 5.5f;
    [Range(0, 10)] [SerializeField] private float lowJumpMultiplier = 5f;
    const float groundedRadius = .15f;
    [Range(0, 10)] [SerializeField] private float groundGravityScale;
    [Range(0, 10)] [SerializeField] private float airGravityScale;
    [Space]

    [SerializeField] private bool airControl = false;
    [HideInInspector] public bool grounded;
    [Space]

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;

    private Rigidbody2D rigidBody2D;

    private UnityEvent OnLandEvent;

    private float characterMult;

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
                rigidBody2D.gravityScale = groundGravityScale * characterMult;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
        if (!grounded)
        {
            rigidBody2D.gravityScale = airGravityScale * characterMult;
            if ((rigidBody2D.gravityScale > 0 && rigidBody2D.velocity.y < 0) || (rigidBody2D.gravityScale < 0 && rigidBody2D.velocity.y > 0))
            {
                rigidBody2D.velocity += Vector2.up * Mathf.Clamp(rigidBody2D.gravityScale, -1, 1) * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (((rigidBody2D.gravityScale > 0 && rigidBody2D.velocity.y > 0) || (rigidBody2D.gravityScale < 0 && rigidBody2D.velocity.y < 0)) && !Input.GetButton("Jump"))
            {
                rigidBody2D.velocity += Vector2.up * Mathf.Clamp(rigidBody2D.gravityScale, -1, 1) * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }
}
