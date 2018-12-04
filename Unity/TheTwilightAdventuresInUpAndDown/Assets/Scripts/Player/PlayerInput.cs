using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private PlayerMovement playerMovement;
    private PlayerJump playerJump;
    public FlipWorld[] rooms;

    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
        playerJump = GetComponent<PlayerJump>();
        rooms = FindObjectsOfType<FlipWorld>();
        
    }

    void Update() {
        playerMovement.Move(Input.GetAxisRaw("Horizontal"), Input.GetButton("Submit"));
        playerJump.Jump(Input.GetButtonDown("Jump"));
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i].FlipTheWorld(Input.GetButtonDown("FlipWorld"));
        }

        
    }
}
