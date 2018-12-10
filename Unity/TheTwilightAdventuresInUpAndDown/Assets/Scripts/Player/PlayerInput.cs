using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

   
    private CharacterSwitch characterSwitch;
    public FlipWorld[] rooms;
    public bool canFlip = true;
    public string characterInside = "";

    private float direction = 0;

    private void Start() {
        rooms = FindObjectsOfType<FlipWorld>();
        characterSwitch = GetComponent<CharacterSwitch>();
        
    }

    void Update() {

        characterSwitch.GetPlayerMovement().Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Sprint") > 0);
        characterSwitch.GetPlayerJump().Jump(Input.GetButtonDown("Jump"));

        if (Input.GetAxisRaw("Horizontal") != 0)
            direction = Mathf.Sign(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("Submit"))
            characterSwitch.GetInteract().InteractObject(true, direction);
        else if (Input.GetButtonUp("Submit"))
            characterSwitch.GetInteract().InteractObject(false, direction);

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
