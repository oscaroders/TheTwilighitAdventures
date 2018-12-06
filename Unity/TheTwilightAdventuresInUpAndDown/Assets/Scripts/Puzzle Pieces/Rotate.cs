using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : ActionObject
{
    private Quaternion startRotation;
    public float rotation;
    //private Animator animata;
    public bool activate;
    private void Start()
    {
        startRotation = transform.rotation;
        //colliderBox = GetComponent<Collider2D>();
        //animata = GetComponent<Animator>();
    }
    public override void OnActivation(bool activated)
    {
        activate = activated;
        if (activated)
        {
            transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
            //colliderBox.enabled = false;
            //animata.Play("DoorOpen");
        }
        else
        {
            transform.rotation = startRotation;
            //colliderBox.enabled = true;
            //animata.Play("DoorClose");
        }
    }
}
