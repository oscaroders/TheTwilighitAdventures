using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

   
    private CharacterSwitch characterSwitch;
    public FlipWorld[] rooms;

    private void Start() {
        rooms = FindObjectsOfType<FlipWorld>();
        characterSwitch = GetComponent<CharacterSwitch>();
        
    }

    void Update() {

        characterSwitch.GetPlayerMovement().Move(Input.GetAxisRaw("Horizontal"), Input.GetButton("Sprint"));
        characterSwitch.GetPlayerJump().Jump(Input.GetButtonDown("Jump"));
        characterSwitch.GetInteract().InteractObject(Input.GetButtonDown("Submit"));
               
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i].FlipTheWorld(Input.GetButtonDown("FlipWorld"));
        }
        characterSwitch.ChangeCharacter(Input.GetButtonDown("CharacterSwitch"));
        
    }
}
