using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Activator))]

public class AndGate : Activator
{
	public Activator[] activators;

	public void AndGates()
	{
		stateOfActivator = true;
		for (int i = 0; i < activators.Length; i++)
		{
			if (!activators[i].stateOfActivator)
			{
				stateOfActivator = false;
                break;
			}
		}
	}

    private void FixedUpdate()
    {
        AndGates();
    }
}
