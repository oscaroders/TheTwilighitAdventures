using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSettings : MonoBehaviour {

    private static CharacterSettings instance;

    [Header("Movment settings")]
    [Space]

    [Range(0, 10)] [SerializeField] internal float maxJumpHeight = 2.5f;
    [Range(0, 10)] [SerializeField] internal float minJumpHeight = 1f;
    [Range(0, 5)] [SerializeField] internal float timeToJumpApex = 0.4f;
    [Space]
    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff ;
    public Vector2 wallLeap;
    [Space]
    [Range(0, 10)] [SerializeField] internal float wallSlideSpeedMax = 3;
    [Range(0, 10)] [SerializeField] internal float wallStickTime = .25f;
    
    // Use this for initialization
    void Start () {
		if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

	}
}
