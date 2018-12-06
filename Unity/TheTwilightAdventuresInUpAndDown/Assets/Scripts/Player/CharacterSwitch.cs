using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public PlayerMovement eveMovement;
    public PlayerJump eveJump;
    public PlayerMovement dodoMovement;
    public PlayerJump dodoJump;
    public bool isEve = true;

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

    public void ChangeCharacter(bool state)
    {
        if(state)
        {
            isEve = !isEve;
            
        }
    }

}