using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : Controller2D {

    CharacterSettings settings;
    public PlayerJump playerJump;
    public PlayerMovement playerMovement;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

    public float gravity;
    internal Vector3 velocity;
    float velocityXSmoothing;
    internal float maxJumpVelocity;
    internal float minJumpVelocity;

    float timeToWallUnstick;

    internal Vector2 directionalInput;
    internal int wallDirX;
    internal bool wallSliding;

    public override void Start()
    {
        base.Start();
        settings = FindObjectOfType<CharacterSettings>();
        playerJump = GetComponent<PlayerJump>();
        playerMovement = GetComponent<PlayerMovement>();

        gravity = -(2 * settings.maxJumpHeight) / Mathf.Pow(settings.timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * settings.timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * settings.minJumpHeight);
    }

    private void Update()
    {
        CalculateVelocity();
        HandleWallSliding();
        Move(velocity * Time.deltaTime, directionalInput);
    }
    
    void HandleWallSliding()
    {
        wallDirX = (collisions.left) ? -1 : 1;
        wallSliding = false;
        if ((collisions.left || collisions.right) && !collisions.below && velocity.y < 0)
        {
            wallSliding = true;

            if (velocity.y < -settings.wallSlideSpeedMax)
            {
                velocity.y = -settings.wallSlideSpeedMax;
            }

            if (timeToWallUnstick > 0)
            {
                velocityXSmoothing = 0;
                velocity.x = 0;

                if (directionalInput.x != wallDirX && directionalInput.x != 0)
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick = settings.wallStickTime;
                }
            }
            else
            {
                timeToWallUnstick = settings.wallStickTime;
            }

        }

    }

    void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
    }
}
