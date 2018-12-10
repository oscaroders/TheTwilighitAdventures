using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Activator))]

public class Crank : ActiveInteractableObject
{
	private Activator activator;
	public int timesPressed;
	public int requiredPressed;
    //public float timer;
    //private float currentTime;
    //public bool timerOn;
    private float timeSinceLastInteract;
    private float completionTime;
    public float limitTime;

	// Use this for initialization
	void Start ()
	{
		activator = GetComponent<Activator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        
	}

    public override void Interact(bool interacting)
    {
        if (timeSinceLastInteract == 0)
        {
            timeSinceLastInteract = Time.time;
        }
        float previousTime = timeSinceLastInteract;
        float deltaBetweenInteract;
        timesPressed++;
        timeSinceLastInteract = Time.time;
        deltaBetweenInteract = timeSinceLastInteract - previousTime;
        completionTime += deltaBetweenInteract;

        if (timesPressed == requiredPressed && completionTime < limitTime)
        {
            activator.stateOfActivator = true;
        }
        if (completionTime > limitTime)
        {
            timesPressed = 0;
            completionTime = 0;
            timeSinceLastInteract = 0;
        }
    }
}
