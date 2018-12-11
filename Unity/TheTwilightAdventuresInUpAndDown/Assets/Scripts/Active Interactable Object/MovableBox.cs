using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(FixedJoint2D))]
public class MovableBox : ActiveInteractableObject
{
    private bool moving;
    private FixedJoint2D box;
    private float xPos;
    [SerializeField] private GameObject inputController;
    private PlayerInput input;
    private Rigidbody2D[] playerRigidbody2D;
    private Rigidbody2D boxRB;
    private CharacterSwitch characterSwitch;
    [SerializeField] private float boxMassStop, boxMassMoving;
    private void Start()
    {
        box = GetComponent<FixedJoint2D>();
        xPos = transform.position.x;
        boxRB = GetComponent<Rigidbody2D>();
        input = inputController.GetComponent<PlayerInput>();
        playerRigidbody2D = inputController.GetComponentsInChildren<Rigidbody2D>();
        characterSwitch = inputController.GetComponent<CharacterSwitch>();
    }
    public override void Interact(bool interacting)
    {
        if (interacting)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
    }
    private void FixedUpdate()
    {
        if (moving)
        {
            input.notInteracting = false;
            box.connectedBody = playerRigidbody2D[characterSwitch.isEve.GetHashCode()];
            xPos = transform.position.x;
            gameObject.layer = 8;
            boxRB.mass = boxMassMoving;
        }
        else
        {
            input.notInteracting = true;
            transform.position = new Vector3(xPos, transform.position.y, 0);
            gameObject.layer = 9;
            boxRB.mass = boxMassStop;
        }
        box.enabled = moving;
    }
}