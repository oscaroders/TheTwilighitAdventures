using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Activator))]
public class Lever : ActiveInteractableObject
{
    private Activator activator;
	void Start()
    {
        activator = GetComponent<Activator>();
	}
	public override void Interact(bool interacting)
    {
        if(interacting)
            activator.stateOfActivator = !activator.stateOfActivator; 
	}
}