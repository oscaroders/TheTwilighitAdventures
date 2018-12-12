using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

   
    private CharacterSwitch characterSwitch;
    public Room[] rooms;
    public bool canFlip = true;
    public string characterInside = "";
    public bool notInteracting = true;
    public int currentRoomId;

    private float direction = 0;

    private void Start() {
        rooms = FindObjectsOfType<Room>();
        characterSwitch = GetComponent<CharacterSwitch>();
        
    }

    void Update() {

        characterSwitch.GetPlayerMovement().Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Sprint") > 0);

        if (notInteracting)
        {
            characterSwitch.GetPlayerJump().Jump(Input.GetButtonDown("Jump"));
            characterSwitch.ChangeCharacter(Input.GetButtonDown("CharacterSwitch"));
        }

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
                rooms[i].FlipThisRoomsFlippableObjects(currentRoomId,Input.GetButtonDown("FlipWorld"));
            }
        }
        
        
        
    }
}
