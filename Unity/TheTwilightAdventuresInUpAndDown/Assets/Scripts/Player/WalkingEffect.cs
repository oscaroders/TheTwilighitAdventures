using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEffect : MonoBehaviour {

    public GameObject particleEffectPrefab;

    private BoxCollider2D boxCollider;
    private ParticleSystem particleSystem;
    private PlayerController playerController;

    // Use this for initialization
    void Start () {

        boxCollider = GetComponent<BoxCollider2D>();
        playerController = GetComponent<PlayerController>();
        particleSystem = Instantiate(particleEffectPrefab, transform).GetComponent<ParticleSystem>();

        particleSystem.transform.position += new Vector3(0, -boxCollider.size.y/2);
       
        
    }
	
	// Update is called once per frame
	void Update () {
        if (playerController.velocity.y == 0 && playerController.velocity.magnitude > 1)
        {
            particleSystem.Play();
        }
        else
        {
            particleSystem.Stop();
        }
    }
}
