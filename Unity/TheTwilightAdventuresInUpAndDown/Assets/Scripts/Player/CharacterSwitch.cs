using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public PlayerMovement eveMovement;
    public PlayerJump eveJump;
    public Interact eveInteract;
    public PlayerMovement dodoMovement;
    public PlayerJump dodoJump;
    public Interact dodoInteract;
    public bool isEve = true;

    public void ChangeCharacter(bool state)
    {
        if (state)
        {
            isEve = !isEve;

        }
    }


    public PlayerMovement GetPlayerMovement()
    {

        if(isEve)
        {
            return eveMovement;
        }
        else
        {
            return dodoMovement;
        }
        
    }
    public PlayerJump GetPlayerJump()
    {
        if(isEve)
        {
            return eveJump;
        }
        else
        {
            return dodoJump;
        }
    }
    public Interact GetInteract()
    {
        if(isEve)
        {
            return eveInteract;
        }
        else
        {
            return dodoInteract;
        }
    }

   

}