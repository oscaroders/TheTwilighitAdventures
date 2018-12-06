using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : ActionObject
{
    private Quaternion startRotation;
    public float rotation;
    public bool activate;

    private void Start()
    {
        startRotation = transform.rotation;
    }
    public override void OnActivation(bool activated)
    {
        activate = activated;
        if (activated)
        {
            transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);           
        }
        else
        {
            transform.rotation = startRotation;
        }
    }
}
