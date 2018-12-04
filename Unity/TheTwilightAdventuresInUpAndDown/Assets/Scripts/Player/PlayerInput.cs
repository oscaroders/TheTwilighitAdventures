using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private PlayerMovement playerMovement;
    private PlayerJump playerJump;

    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
        playerJump = GetComponent<PlayerJump>();
    }

    void Update() {
        playerMovement.Move(Input.GetAxisRaw("Horizontal"), Input.GetButton("Submit"));
        playerJump.Jump(Input.GetButtonDown("Jump"));
    }
}
