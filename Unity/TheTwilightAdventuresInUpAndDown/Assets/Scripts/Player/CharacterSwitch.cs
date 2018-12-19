using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public PlayerMovement eveMovement;
    public PlayerJump eveJump;
    public Interact eveInteract;
	public AudioSource eveAmbientSound;
	public PlayerMovement dodoMovement;
    public PlayerJump dodoJump;
    public Interact dodoInteract;
	public AudioSource dodoAmbientSound;
    public bool isEve = true;

    public void ChangeCharacter(bool state)
    {
        if (state)
        {
            isEve = !isEve;
        }
	}

	public void BackGroundMusic()
	{
		if (isEve && !eveAmbientSound.isPlaying)
		{ 
			dodoAmbientSound.Pause();
			eveAmbientSound.Play();
		}
		else if(!isEve && !dodoAmbientSound.isPlaying)
		{
			eveAmbientSound.Pause();
			dodoAmbientSound.Play();
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