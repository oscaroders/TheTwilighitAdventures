using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Activator))]
[RequireComponent(typeof(BoxCollider2D))]
public class PressurePlate : MonoBehaviour
{
    public Activator activator;
    public bool timerOn;
    public float timer;
    private float currentTime;
    private bool off = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        activator.Activate(true);
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
            activator.Activate(false);
        if(timerOn)
            currentTime += Time.deltaTime;
    }
}