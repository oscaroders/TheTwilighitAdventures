using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Zone))]
public class OutOfBounds : ActionObject
{
    public Transform eve, dodo;
    public Transform eveCheckpoint, dodoCheckpoint;
    public override void OnActivation(bool activated)
    {
        if (activated)
        {
            eve.position = eveCheckpoint.position;
            dodo.position = dodoCheckpoint.position;
        }
    }
}