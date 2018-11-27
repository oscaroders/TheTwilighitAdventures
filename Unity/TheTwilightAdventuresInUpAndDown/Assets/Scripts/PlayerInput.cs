using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public PlayerMovement move;
    //jump variable?
	
	// Update is called once per frame
	void Update () {
        move.Movement(Input.GetAxisRaw("Horizontal"));
        //jump input + script HERE
	}
}
