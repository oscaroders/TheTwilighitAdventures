using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ActionObject : MonoBehaviour
{
    public Activator[] activators;
    private bool allActive = false;
    public virtual void OnActivation(bool activated)
    {

    }
    private void FixedUpdate()
    {
        OnFixedUpdate();
    }
    public virtual void OnFixedUpdate()
    {
        allActive = true;
        foreach (Activator activator in activators)
        {
            if (!activator.stateOfActivator)
                allActive = false;
        }
        OnActivation(allActive);
    }
}