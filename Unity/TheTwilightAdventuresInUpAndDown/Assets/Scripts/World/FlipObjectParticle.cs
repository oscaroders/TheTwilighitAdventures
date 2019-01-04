using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ParticleSystem))]
public class FlipObjectParticle : MonoBehaviour {

    private ParticleSystem flipParticles;
    private SpriteRenderer spriteRenderer;
    public Color particleColor = Color.magenta;
    private GameObject[] players;
    private Vector3 distanceEve;
    private Vector3 distanceDodo;
    public float maxDistance;
    //private Room room;
    public int roomId;
    public float TdistanceEve;
    public float TdistanceDodo;

    private PlayerInput playerInput;
    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        flipParticles = GetComponent<ParticleSystem>();
        players = GameObject.FindGameObjectsWithTag("Player");
        roomId = GetComponentInParent<Room>().roomId;
        playerInput = FindObjectOfType<PlayerInput>();
        distanceEve = players[0].transform.position - flipParticles.transform.position;
        distanceDodo = players[1].transform.position - flipParticles.transform.position;
        ParticlePreset();
	}

    public void Update()
    {
        if (playerInput.currentRoomId == roomId)
        {
            distanceEve = players[0].transform.position - transform.position;
            distanceDodo = players[1].transform.position - transform.position;
            PlayerParticleProximityCheck();
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

    public void PlayerParticleProximityCheck()
    {
        TdistanceEve = distanceEve.magnitude;
        TdistanceDodo = distanceDodo.magnitude;


        if (distanceEve.magnitude < distanceDodo.magnitude)
        {
            if (distanceEve.magnitude < maxDistance)
            {
                if (!flipParticles.isPlaying)
                {
                    flipParticles.Play();
                }
            }
            else if (distanceEve.magnitude > maxDistance)
            {
                flipParticles.Stop();
            }
        }

        if (distanceDodo.magnitude < distanceEve.magnitude)
        {
            if (distanceDodo.magnitude < maxDistance)
            {
                if (!flipParticles.isPlaying)
                {
                    flipParticles.Play();
                }
            }
            else if (distanceDodo.magnitude > maxDistance)
            {
                flipParticles.Stop();
            }
        }
    }
}
