using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeLantern : MonoBehaviour {

    private PlayerInput playerInput;
    // Use this for initialization
    void Start () {
        playerInput = FindObjectOfType<PlayerInput>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInput.eveHasLantern = true;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
