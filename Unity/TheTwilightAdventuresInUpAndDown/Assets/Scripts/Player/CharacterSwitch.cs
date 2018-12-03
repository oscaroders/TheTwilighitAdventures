using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public PlayerInput eve, dodo;
    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.K))
        {
            //eve.move.Movement(0);
            //eve.enabled = !eve.enabled;
            //dodo.move.Movement(0);
            //dodo.enabled = !dodo.enabled;
        }
	}
}