using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ParticleSystem))]
public class FlipObjectParticle : MonoBehaviour {

    private ParticleSystem flipParticles;
    private SpriteRenderer spriteRenderer;
    public Color particleColor = Color.magenta;
    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        flipParticles = GetComponent<ParticleSystem>();
        ParticlePreset();
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
}
