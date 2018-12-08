using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

   
    private CharacterSwitch characterSwitch;
    public FlipWorld[] rooms;
    public bool canFlip = true;
    private void Start() {
        rooms = FindObjectsOfType<FlipWorld>();
        characterSwitch = GetComponent<CharacterSwitch>();
        
    }

    void Update() {

        characterSwitch.GetPlayerMovement().Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Sprint") > 0);
        characterSwitch.GetPlayerJump().Jump(Input.GetButtonDown("Jump"));
        characterSwitch.GetInteract().InteractObject(Input.GetButtonDown("Submit"));
        if (canFlip)
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i].FlipTheWorld(Input.GetButtonDown("FlipWorld"));
            }
        }
        characterSwitch.ChangeCharacter(Input.GetButtonDown("CharacterSwitch"));
        
        
        
    }
}
