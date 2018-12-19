using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public int roomId;
    [Header("Room Edges Positions")]
    public Transform topPosition;
    public Transform middlePosition;
    public Transform leftPosition;
    public Transform rightPosition;
    public Transform bottomPosition;

    [Header("Spawn Point")]
    public Transform eveSpawnPosition;
    public Transform dodoSpawnPosition;

    private FlipWorld flipWorld;
	// Use this for initialization
	void Start () {
        flipWorld = GetComponent<FlipWorld>();
	}
	
    public void FlipThisRoomsFlippableObjects(int room, bool button)
    {
        if(room == roomId && flipWorld != null)
        {
            flipWorld.FlipTheWorld(button);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
