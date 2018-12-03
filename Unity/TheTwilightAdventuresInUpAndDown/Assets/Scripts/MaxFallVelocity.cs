using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxFallVelocity : MonoBehaviour {

	Rigidbody2D rigidBody2D;
	Vector2 velocity;
	[Range(0, 100)]public float maxVelocity;

	// Use this for initialization
	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();
		velocity = rigidBody2D.velocity;
	}
	
	// Update is called once per frame
	void Update () {
		velocity = rigidBody2D.velocity;
		velocity.y = Mathf.Clamp(velocity.y, -maxVelocity, maxVelocity);
		Debug.Log(rigidBody2D.velocity);

		rigidBody2D.velocity = new Vector2(velocity.x, velocity.y);
	}
}
