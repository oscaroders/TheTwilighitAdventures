﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

   
    private CharacterSwitch characterSwitch;
    CameraShake[] camShake;
    public Room[] rooms;
    public bool canFlip = true;
    public string characterInside = "";
    public bool notInteracting = true;
    public int currentRoomId;

    private float direction = 0;
    public PlayerController evePlayer;
    public PlayerController dodoPlayer;
    public bool IsEveInFocus = true;

    private void Start() {
        camShake = GetComponentsInChildren<CameraShake>();
        rooms = FindObjectsOfType<Room>();
        characterSwitch = GetComponent<CharacterSwitch>();
    }

    void Update() {

        //characterSwitch.PlayerMovement(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Sprint") > 0);

        if(Input.GetButtonDown("CharacterSwitch"))
        {
            IsEveInFocus = !IsEveInFocus;
        }


        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(IsEveInFocus)
        {
            CharacterSwitchMovment(directionalInput,evePlayer, dodoPlayer);
            CharacterSwitchJump(Input.GetButton("Jump"), evePlayer, dodoPlayer);
            

        }
        else
        {
            CharacterSwitchMovment(directionalInput, dodoPlayer, evePlayer);
            CharacterSwitchJump(Input.GetButton("Jump"), dodoPlayer, evePlayer);

        }
        //      if (notInteracting)
        //      {
        //          characterSwitch.GetPlayerJump().Jump(Input.GetButtonDown("Jump"));
        //          characterSwitch.ChangeCharacter(Input.GetButtonDown("CharacterSwitch"));
        //      }
        //characterSwitch.BackGroundMusic();

        //if (Input.GetAxisRaw("Horizontal") != 0)
        //          direction = Mathf.Sign(Input.GetAxisRaw("Horizontal"));
        //      if (Input.GetButtonDown("Interact") && CanInteract())
        //          characterSwitch.GetInteract().InteractObject(true, direction);
        //      else if (Input.GetButtonUp("Interact"))
        //          characterSwitch.GetInteract().InteractObject(false, direction);

        if (canFlip)
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i].FlipThisRoomsFlippableObjects(currentRoomId, Input.GetButtonDown("FlipWorld"));
            }
        }

        if (!canFlip && Input.GetButtonDown("FlipWorld")) {
            CannotFlipShake();


        }
  
    }
    public void CannotFlipShake()
    {
        foreach (var cam in camShake)
        {
            cam.Shake(0.05f, 0.1f);
        }
    }
    private bool CanInteract()
    {
        //foreach (PlayerController controller in bothPlayerController)
        //{
        //    if (!controller.canInteract)
        //        return false;
        //}
        return true;
    }

    private void CharacterSwitchMovment(Vector2 directionalInput,PlayerController focusPlayer, PlayerController otherFocusPlayer)
    {
        focusPlayer.SetDirectionalInput(directionalInput);
       
        otherFocusPlayer.SetDirectionalInput(Vector2.zero);
        
    }
    private void CharacterSwitchJump(bool playerWantToJump, PlayerController focusPlayer, PlayerController otherFocusPlayer)
    {
        if (playerWantToJump)
        {
            focusPlayer.OnJumpInputDown();
        }
        else
        {
            focusPlayer.OnJumpInputUp();
        }
        otherFocusPlayer.OnJumpInputUp();
    }
}
