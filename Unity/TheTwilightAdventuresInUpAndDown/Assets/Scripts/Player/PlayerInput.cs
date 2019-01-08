using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

   
    
    CameraShake[] camShake;
    public Room[] rooms;
    public bool canFlip = true;
    public string characterInside = "";
    public bool notInteracting = true;
    public int currentRoomId;

    private float direction = 0;

    [Header("Characters")]
    public PlayerController evePlayer;
    public PlayerController dodoPlayer;
    public bool IsEveInFocus = true;

    [Header("Lantern")]
    public bool eveHasLantern;
    public GameObject lanterLight;
    private void Start() {
        camShake = GetComponentsInChildren<CameraShake>();
        rooms = FindObjectsOfType<Room>();
        
    }

    void Update() {
        
        if (Input.GetAxisRaw("Horizontal") != 0)
            direction = Mathf.Sign(Input.GetAxisRaw("Horizontal"));
        //characterSwitch.PlayerMovement(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Sprint") > 0);

        if (Input.GetButtonDown("CharacterSwitch") && eveHasLantern)
        {
            IsEveInFocus = !IsEveInFocus;
        }


        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(IsEveInFocus)
        {
            CharacterSwitchMovment(directionalInput,evePlayer, dodoPlayer);

            if (Input.GetButtonDown("Jump")) { 
                CharacterSwitchJump(true, evePlayer, dodoPlayer);
                
            } else if (Input.GetButtonUp("Jump")) {
                CharacterSwitchJump(false, evePlayer, dodoPlayer);
            }

            if (CanInteract() && Input.GetButtonDown("Interact"))
            {
                CharacterSwitchInteract(true, direction, evePlayer, dodoPlayer);
            }
            else if (Input.GetButtonUp("Interact"))
            {
                CharacterSwitchInteract(false, direction, evePlayer, dodoPlayer);
            }
        }
        else
        {

            CharacterSwitchMovment(directionalInput, dodoPlayer, evePlayer);

            if (Input.GetButtonDown("Jump")) {
                CharacterSwitchJump(true, dodoPlayer, evePlayer);

            } else if (Input.GetButtonUp("Jump")) {
                CharacterSwitchJump(false, dodoPlayer, evePlayer);
            }

            if(CanInteract() && Input.GetButtonDown("Interact"))
            {
                CharacterSwitchInteract(true, direction, dodoPlayer, evePlayer);
            }
            else if (Input.GetButtonUp("Interact"))
            {
                CharacterSwitchInteract(false, direction, dodoPlayer, evePlayer);
            }
           


        }
        
        if (eveHasLantern)
        {
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
    private void CharacterSwitchInteract(bool input, float direction, PlayerController focusPlayer, PlayerController otherFocusPlayer)
    {
        focusPlayer.playerInteract.InteractObject(input, direction);
        otherFocusPlayer.playerInteract.InteractObject(false, direction);
    }
}
