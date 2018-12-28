using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingEffect : MonoBehaviour {

    private ParticleSystem particleSystem;
    private PlayerController playerController;
    private bool hasLanded;

	// Use this for initialization
	void Start () {
        ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particle in particleSystems)
        {
            if (particle.tag == "Landing")
            {
                particleSystem = particle;
            }
        }
        playerController = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        //if (playerController.grounded && hasLanded == false)
        //{
        //    particleSystem.Play();
        //    hasLanded = true;
        //}
        //if (playerController.grounded == false)
        //{
        //    hasLanded = false;
        //}
	}
}
