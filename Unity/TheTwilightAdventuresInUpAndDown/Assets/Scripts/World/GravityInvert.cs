using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityInvert : MonoBehaviour {

    public bool invertedGravity;
    Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if(invertedGravity)
            rigidbody2D.gravityScale *= -1;
	}
}
