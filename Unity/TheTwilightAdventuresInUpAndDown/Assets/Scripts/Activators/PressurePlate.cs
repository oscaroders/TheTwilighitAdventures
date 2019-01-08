using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Activator))]
[RequireComponent(typeof(BoxCollider2D))]
public class PressurePlate : MonoBehaviour
{
    private Activator activator;
    private int counter;
    public bool timerOn;
    public float timer;
	public AudioSource plateSound;
    private float currentTime;
    private bool off = true;
    private Animator animator;

    private void Start()
    {
        activator = GetComponent<Activator>();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
	{
		plateSound.Play();
		activator.stateOfActivator = true;
        counter++;
        off = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
	{
		currentTime = 0;
        counter--;
        if(counter == 0)
			off = true;
    }
    private void Update()
    {
        if (off && (!timerOn || currentTime > timer))
            activator.stateOfActivator = false;
		if (timerOn)
            currentTime += Time.deltaTime;

        animator.SetBool("IsOn", activator.stateOfActivator);
    }
}