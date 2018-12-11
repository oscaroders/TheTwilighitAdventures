using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Activator))]

public class OrGate : Activator
{
	public Activator[] activators;

	public void OrGates()
	{
		stateOfActivator = false;
		for (int i = 0; i < activators.Length; i++)
		{
			if (activators[i].stateOfActivator)
			{
				stateOfActivator = true;
				break;
			}
		}
	}

	private void FixedUpdate()
	{
		OrGates();
	}
}

