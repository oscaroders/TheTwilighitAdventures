using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Activator))]
[RequireComponent(typeof(BoxCollider2D))]
public class PressurePlate : MonoBehaviour
{
    private Activator activator;
    public bool timerOn;
    public float timer;
    private float currentTime;
    private bool off = true;
    private void Start()
    {
        activator = GetComponent<Activator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        activator.stateOfActivator = true;
        off = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        currentTime = 0;
        off = true;
    }
    private void Update()
    {
        if (off && (!timerOn || currentTime > timer))
            activator.stateOfActivator = false;
        if(timerOn)
            currentTime += Time.deltaTime;
    }
}