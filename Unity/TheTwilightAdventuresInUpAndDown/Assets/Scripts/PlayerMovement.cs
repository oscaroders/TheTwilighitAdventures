using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public Rigidbody2D rigidbody2D;
	
	
	public void Movement (float direction) {

        float x = direction * speed;

        rigidbody2D.velocity = new Vector2(x, rigidbody2D.velocity.y);
    }
}
