using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private Transform playerCenter;
    [SerializeField] private float interactRadius;
    [SerializeField] private LayerMask whatIsInteractable;
    private ActiveInteractableObject interactiveObject;

    public void InteractObject(bool interacting, float direction)
    {
        if (interacting)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(playerCenter.position.x, playerCenter.position.y), new Vector2(direction, 0), interactRadius, whatIsInteractable);
            if (hit)
            {
                interactiveObject = hit.collider.gameObject.GetComponent<ActiveInteractableObject>();
                interactiveObject.Interact(interacting);
            }
        }
        else if (interactiveObject != null)
        {
            interactiveObject.Interact(interacting);
            interactiveObject = null;
        }
    }
}