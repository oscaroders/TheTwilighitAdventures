using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Activator))]

public class AndGate : Activator
{
	public Activator[] activators;
	private bool allActive = false;

	public virtual void OnActivation(bool activated)
	{

	}

	public void AndGates()
	{
		allActive = true;
		for (int i = 0; i < activators.Length; i++)
		{
			if (!activators[i].stateOfActivator)
			{
				allActive = false;
			}
		}
		OnActivation(allActive);
	}
}
