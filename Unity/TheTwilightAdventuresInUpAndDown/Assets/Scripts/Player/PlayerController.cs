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
    const float groundedRadius = .2f;
    [Space]

    [SerializeField] private bool airControl = false;
    [HideInInspector] public bool grounded;
    [Space]

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;

    private Rigidbody2D rigidBody2D;

    private UnityEvent OnLandEvent;

    private void Awake() {
        rigidBody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    private void FixedUpdate() {

        bool wasGrounded = grounded;
        grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject != gameObject) {
                grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }

        if (rigidBody2D.velocity.y < 0) {
            rigidBody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rigidBody2D.velocity.y > 0 && !Input.GetButton("Jump")) {
            rigidBody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
