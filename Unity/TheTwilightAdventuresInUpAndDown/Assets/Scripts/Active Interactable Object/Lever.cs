using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Activator))]
public class Lever : ActiveInteractableObject
{
    private Activator activator;
	public AudioSource leverSound;
    public Animator animator;
	void Start()
    {
        activator = GetComponent<Activator>();
        animator = GetComponent<Animator>();
	}

	public override void Interact(bool interacting)
    {
        if(interacting)
		{
			leverSound.Play();
			activator.stateOfActivator = !activator.stateOfActivator;
            animator.SetBool("isOn", activator.stateOfActivator);

		}
	}
}