using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBoxPhysics : Controller2D {


    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 0;

    public float gravity = -9.68f;
    internal Vector3 velocity;
    float velocityXSmoothing;
    internal float maxJumpVelocity;
    internal float minJumpVelocity;

    float timeToWallUnstick;

    internal Vector2 directionalInput;
    BetterMovableBox betterMovableBox;
   
    // Use this for initialization
    public override void Start () {
        base.Start();
        betterMovableBox = GetComponent<BetterMovableBox>();
        
	}
	
	// Update is called once per frame
	void Update () {
        CalculateVelocity();
        
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
    void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
    }
    public void InteractPhysics(Vector3 playerOneVelocity, Vector3 playerTwoVelocity, bool isEve)
    {
        if(isEve)
        {
            Move(playerOneVelocity * Time.deltaTime, new Vector2(Mathf.Sign(playerOneVelocity.x), 0));
        }
        else if(!isEve)
        {
            Move(playerTwoVelocity * Time.deltaTime, new Vector2(Mathf.Sign(playerTwoVelocity.x), 0));
        }
    }
    private new void Move(Vector2 moveAmount, Vector2 input, bool standingOnPlatform = false)
    {
        UpdateRaycastOrigins();

        collisions.Reset();
        collisions.moveAmountOld = moveAmount;
        playerInput = input;

        if (moveAmount.y < 0)
        {
            DescendSlope(ref moveAmount);
        }

        if (moveAmount.x != 0)
        {
            collisions.faceDir = (int)Mathf.Sign(moveAmount.x);
        }
        if(betterMovableBox.moving)
            HorizontalCollisions(ref moveAmount);
        if (moveAmount.y != 0)
        {
            VerticalCollisions(ref moveAmount);
        }

        transform.Translate(moveAmount);

        if (standingOnPlatform)
        {
            collisions.below = true;
        }
    }
}
