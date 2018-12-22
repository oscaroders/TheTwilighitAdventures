using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    private Rigidbody2D rigidBody2D;
    private PlayerController playerController;
	public AudioSource jumpSound;
    private CharacterSettings characterSettings;

    // Use this for initialization
    void Start() {
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        characterSettings = FindObjectOfType<CharacterSettings>();
    }

    internal void Jump(bool jump) {
        if (jump && playerController.grounded)
		{
			jumpSound.Play();
			rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, Mathf.Sign(rigidBody2D.gravityScale) * characterSettings.jumpSpeed);
            playerController.canInteract = false;
		}
	}

    private void FixedUpdate()
    {
        if (!playerController.grounded)
        {
            playerController.canInteract = false;
            bool falling = (rigidBody2D.gravityScale > 0 && rigidBody2D.velocity.y < 0) || (rigidBody2D.gravityScale < 0 && rigidBody2D.velocity.y > 0);
            bool goiningUp = (rigidBody2D.gravityScale > 0 && rigidBody2D.velocity.y > 0) || (rigidBody2D.gravityScale < 0 && rigidBody2D.velocity.y < 0);
            bool reachingHeight = Mathf.Abs(transform.position.y - playerController.yGroundPosition) >= characterSettings.jumpHeight;

            rigidBody2D.gravityScale = characterSettings.airGravityScale * playerController.characterMult;

            if (falling)
            {
                rigidBody2D.velocity += Vector2.up * playerController.characterMult * Physics2D.gravity.y * (characterSettings.fallMultiplier - 1) * Time.deltaTime;
            }
            else if (goiningUp && reachingHeight)
            {
                rigidBody2D.velocity += Vector2.up * playerController.characterMult * Physics2D.gravity.y * (characterSettings.lowJumpMultiplier - 1) * Time.deltaTime;
            }
            else if (goiningUp && !Input.GetButton("Jump"))
            {
                rigidBody2D.velocity += Vector2.up * playerController.characterMult * Physics2D.gravity.y * (characterSettings.lowJumpMultiplier - 1) * Time.deltaTime;
            }
            
        }
    }
}
