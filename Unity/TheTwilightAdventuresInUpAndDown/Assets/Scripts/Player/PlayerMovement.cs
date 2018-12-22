using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigidBody2D;
    private PlayerController playerController;
    private CharacterSettings characterSettings;


    void Start() {
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        characterSettings = FindObjectOfType<CharacterSettings>();
    }

    internal void Move(float direction, bool sprint) {

        Vector2 velocity = rigidBody2D.velocity;

        float acceleration = 0;
        float drag = 0;

        if (!playerController.grounded) {
            acceleration = characterSettings.accelerationAir;
            drag = characterSettings.dragAir;
        } else if (sprint) {
            acceleration = characterSettings.accelerationGround * characterSettings.sprintMultiplier;
            drag = characterSettings.dragGround;
        } else {
            acceleration = characterSettings.accelerationGround;
            drag = characterSettings.dragGround;
        }

        velocity.x += (acceleration * direction - drag * velocity.x) * Time.deltaTime;
        velocity.x = Mathf.Clamp(velocity.x, -characterSettings.v_Max, characterSettings.v_Max);

        rigidBody2D.velocity = new Vector2(velocity.x, velocity.y);
    }
}
