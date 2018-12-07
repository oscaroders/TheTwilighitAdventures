using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Activator))]

public class Crank : MonoBehaviour
{
	private Activator activator;
	private int timesPressed;
	public int requiredPressed;

	// Use this for initialization
	void Start ()
	{
		activator = GetComponent<Activator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown("Interact"))
		{
			timesPressed++;
		}

		if (timesPressed == requiredPressed)
		{
			activator.stateOfActivator = true;
		}
	}
}
