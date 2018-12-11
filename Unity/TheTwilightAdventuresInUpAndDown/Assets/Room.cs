using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    internal int roomId;
    [Header("Room Edges Positions")]
    public Transform topPosition;
    public Transform middlePosition;
    public Transform leftPosition;
    public Transform rightPosition;
    public Transform bottomPosition;

    [Header("Spawn Point")]
    public Transform evePosition;
    public Transform dodoPosition;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
