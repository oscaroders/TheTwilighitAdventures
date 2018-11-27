using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public PlayerMovement move;
    public Jump jump;
	
	// Update is called once per frame
	void Update () {
        move.Movement(Input.GetAxisRaw("Horizontal"));
        jump.Jumping(Input.GetAxisRaw("Jump"));
	}
}
