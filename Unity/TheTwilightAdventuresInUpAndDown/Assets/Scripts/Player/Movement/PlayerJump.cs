using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerController))]
public class PlayerJump : MonoBehaviour {

    AudioSource playerSounds;
    CharacterSettings settings;
    PlayerController controller;
    private void Start()
    {
        playerSounds = GetComponent<AudioSource>();
        controller = GetComponent<PlayerController>();
        settings = controller.settings;
    }

    public void OnJumpInputDown()
    {
        if (controller.wallSliding)
        {
            if (controller.wallDirX == controller.directionalInput.x)
            {
                
                controller.velocity.x = -controller.wallDirX * settings.wallJumpClimb.x;
                controller.velocity.y = settings.wallJumpClimb.y;
            }
            else if (controller.directionalInput.x == 0)
            {
                controller.velocity.x = -controller.wallDirX * settings.wallJumpOff.x;
                controller.velocity.y = settings.wallJumpOff.y;
            }
            else
            {
                controller.velocity.x = -controller.wallDirX * settings.wallLeap.x;
                controller.velocity.y = settings.wallLeap.y;
            }
        }
        if (controller.collisions.below)
        {
            playerSounds.Play();
            if (controller.collisions.slidingDownMaxSlope)
            {
                if (controller.directionalInput.x != -Mathf.Sign(controller.collisions.slopeNormal.x))
                { // not jumping against max slope
                    controller.velocity.y = controller.maxJumpVelocity * controller.collisions.slopeNormal.y;
                    controller.velocity.x = controller.maxJumpVelocity * controller.collisions.slopeNormal.x;
                }
            }
            else
            {
                controller.velocity.y = controller.maxJumpVelocity;
            }
        }
    }
    public void OnJumpInputUp()
    {
        if (controller.velocity.y > controller.minJumpVelocity)
        {
            controller.velocity.y = controller.minJumpVelocity;
        }
    }
}
