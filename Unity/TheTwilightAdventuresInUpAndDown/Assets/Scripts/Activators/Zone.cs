using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Activator))]
public class Zone : MonoBehaviour
{
    private Activator activator;
    public string targetTag;
    private void Start()
    {
        activator = GetComponent<Activator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            activator.Activate(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            activator.Activate(false);
        }
    }
}