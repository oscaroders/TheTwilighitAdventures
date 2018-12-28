using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEffect : MonoBehaviour {

    private Rigidbody2D rigidbody2D;
    private ParticleSystem particleSystem;
    private PlayerController playerController;

    // Use this for initialization
    void Start () {
        ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particle in particleSystems)
        {
            if (particle.tag == "Moving")
            {
                particleSystem = particle;
            }
        }
        playerController = GetComponent<PlayerController>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        //if (playerController.grounded && rigidbody2D.velocity.magnitude > 1)
        //{
        //    particleSystem.Play();
        //}
        //else
        //{
        //    particleSystem.Stop();
        //}
	}
}
