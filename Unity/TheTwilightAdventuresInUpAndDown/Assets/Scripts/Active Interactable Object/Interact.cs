using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private Transform playerCenter;
    [SerializeField] private float interactRadius;
    [SerializeField] private LayerMask whatIsInteractable;

    public void InteractObject(bool interacting)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(playerCenter.position, interactRadius, whatIsInteractable);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != this.gameObject)
            {
                if (interacting)
                {
                    collider.gameObject.GetComponent<ActiveInteractableObject>().Interact();
                }
            }
        }
    }
}