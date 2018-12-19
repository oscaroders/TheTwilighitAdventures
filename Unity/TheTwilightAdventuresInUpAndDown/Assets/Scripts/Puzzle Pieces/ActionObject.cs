using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ActionObject : MonoBehaviour
{
    public Activator activator;
    public virtual void OnActivation(bool activated)
    {

    }
    private void FixedUpdate()
    {
        OnFixedUpdate();
    }
    public virtual void OnFixedUpdate()
    {
        OnActivation(activator.stateOfActivator);
    }
}