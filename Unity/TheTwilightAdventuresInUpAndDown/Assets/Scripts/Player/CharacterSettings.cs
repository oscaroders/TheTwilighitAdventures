using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSettings : MonoBehaviour {

    private static CharacterSettings instance;

    [Header("Movment settings")]
    [Space]

    [Range(0, 100)] [SerializeField] internal float v_Max = 8f;
    [Space]
    [Range(0, 10)] [SerializeField] internal float dragGround = 6f;
    [Range(0, 10)] [SerializeField] internal float dragAir = 3.5f;
    [Range(0, 200)] [SerializeField] internal float accelerationGround = 60f;
    [Range(0, 200)] [SerializeField] internal float accelerationAir = 20f;
    [Space]
    [Range(0, 10)] [SerializeField] internal float sprintMultiplier = 1f;

    [Header("Jump Settings")]
    [Space]

    [Range(0, 20)] [SerializeField] internal float jumpHeight = 1f;
    [Range(0, 20)] [SerializeField] internal float jumpSpeed = 15f;
    [Range(0, 10)] [SerializeField] internal float fallMultiplier = 4.7f;
    [Range(0, 10)] [SerializeField] internal float lowJumpMultiplier = 1f;
    
    [Range(0, 10)] [SerializeField] internal float groundGravityScale=1f;
    [Range(0, 10)] [SerializeField] internal float airGravityScale=1f;
    [Space]

    [SerializeField] private bool airControl = false;
    // Use this for initialization
    void Start () {
		if(instance == null)
        {
            instance = this;
        }else
        {
            Destroy(this);
        }

	}
}
