using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : Controller2D {

    internal CharacterSettings settings;
    public SpriteRenderer sprite;
    public Interact playerInteract;
    public PlayerJump playerJump;
    public PlayerMovement playerMovement;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;
    float oldDirection = 1;

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
        playerInteract = GetComponent<Interact>();
        gravity = -(2 * settings.maxJumpHeight) / Mathf.Pow(settings.timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * settings.timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * settings.minJumpHeight);
    }

    private void Update()
    {
        CalculateVelocity();
        HandleWallSliding();
        Flip(directionalInput.x);
        Move(velocity * Time.deltaTime, directionalInput);

        if (collisions.above || collisions.below)
        {
            if (collisions.slidingDownMaxSlope)
            {
                velocity.y += collisions.slopeNormal.y * -gravity * Time.deltaTime;
            }
            else
            {
                velocity.y = 0;
            }
        }

    }
    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }
    public void OnJumpInputDown()
    {
        playerJump.OnJumpInputDown();
    }
    public void OnJumpInputUp()
    {
        playerJump.OnJumpInputUp();
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

    void Flip(float direction) {
        
        if (!playerInteract.isInteracting && (direction < -0.01 || direction > 0.01)) {
            // Switch the way the player is labelled as facing
            if(oldDirection > direction && direction < -0.01) {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            } else if(oldDirection < direction && direction > 0.01) {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }

            oldDirection = direction;
        }
    }
}
