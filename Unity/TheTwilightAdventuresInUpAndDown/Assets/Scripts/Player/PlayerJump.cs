using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    private Rigidbody2D rigidBody2D;
    private PlayerController playerController;
	public AudioSource jumpSound;
    public float maxHeight;
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
}
