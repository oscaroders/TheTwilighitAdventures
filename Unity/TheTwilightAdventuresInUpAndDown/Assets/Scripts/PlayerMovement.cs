using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigidBody2D;
    private PlayerController playerController;



    void Start() {
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }

    internal void Move(float direction, bool sprint) {

        Vector2 velocity = rigidBody2D.velocity;

        float acceleration = 0;
        float drag = 0;

        if (!playerController.grounded) {
            acceleration = playerController.accelerationAir;
            drag = playerController.dragAir;
        } else if (sprint) {
            acceleration = playerController.accelerationGround * playerController.sprintMultiplier;
            drag = playerController.dragGround;
        } else {
            acceleration = playerController.accelerationGround;
            drag = playerController.dragGround;
        }

        velocity.x += (acceleration * direction - drag * velocity.x) * Time.deltaTime;
        velocity.x = Mathf.Clamp(velocity.x, -playerController.v_Max, playerController.v_Max);

        rigidBody2D.velocity = new Vector2(velocity.x, velocity.y);
        Debug.Log("vel: " + velocity.x);
    }
}
