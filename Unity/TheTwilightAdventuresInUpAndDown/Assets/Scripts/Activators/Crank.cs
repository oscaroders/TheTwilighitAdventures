using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Activator))]

public class Crank : ActiveInteractableObject
{
	private Activator activator;
	public int timesPressed;
	public int requiredPressed;
    public float timer;
    private float timerStartValue;
    private float timeSinceLastInteract;
    private float completionTime;
    public float limitTime;
    
    void Start ()
	{
		activator = GetComponent<Activator>();
        timerStartValue = timer;
	}
	
	void Update ()
	{
        if (activator.stateOfActivator)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                activator.stateOfActivator = false;
                timesPressed = 0;
                timer = timerStartValue;
            }
        }
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
