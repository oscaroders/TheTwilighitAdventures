using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ParticleSystem))]
public class FlipObjectParticle : MonoBehaviour {

    private ParticleSystem flipParticles;
    private SpriteRenderer spriteRenderer;
    public Color particleColor = Color.magenta;
    private GameObject player;
    private Vector3 distance;
    public float maxDistance;
    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        flipParticles = GetComponent<ParticleSystem>();
        player = GameObject.FindGameObjectWithTag("Player");
        distance = player.transform.position - flipParticles.transform.position;
        ParticlePreset();
	}

    public void Update()
    {
        distance = player.transform.position - transform.position;

        if (distance.magnitude < maxDistance)
        {
            Debug.Log(distance.magnitude);
            if (!flipParticles.isPlaying)
            {
                flipParticles.Play();
            }
            //em.enabled = true;
        }
        else if (distance.magnitude > maxDistance)
        {
            flipParticles.Stop();
        }       
    }

    public void ChangeColor(Color c)
    {
        particleColor = c;
    }


    void ParticlePreset()
    {
        var m = flipParticles.main;
        m.maxParticles = 20;
        m.startColor = particleColor;

        var em = flipParticles.emission;
        em.rateOverTime = 5;

        var sh = flipParticles.shape;
        sh.shapeType = ParticleSystemShapeType.SpriteRenderer;
        sh.spriteRenderer = spriteRenderer;

        var noise = flipParticles.noise;
        noise.enabled = true;
        noise.strength = 0.21f;
        noise.frequency = 0.21f;
    }

    /*public void EmitParticles(int room)
    {
        
    }*/
}
