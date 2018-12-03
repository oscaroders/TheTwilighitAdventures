using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Activator activator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        activator.Activate(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        activator.Activate(false);
    }
}