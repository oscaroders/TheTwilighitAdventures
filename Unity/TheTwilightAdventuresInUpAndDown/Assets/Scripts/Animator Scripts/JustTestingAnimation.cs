using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustTestingAnimation : MonoBehaviour
{
    private Animator animatorPlayer;
    private PlayerController playerController;
    private SpriteRenderer eve;
	void Start ()
    {
        animatorPlayer = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        eve = GetComponentInChildren<SpriteRenderer>();
	}
	void Update ()
    {
        if (playerController.velocity.x > 1 || playerController.velocity.x < -1)
        {
            animatorPlayer.SetBool("moving", true);
        }
        else
            animatorPlayer.SetBool("moving", false);

        animatorPlayer.SetFloat("jumpVelocity", playerController.velocity.y);
	}
}