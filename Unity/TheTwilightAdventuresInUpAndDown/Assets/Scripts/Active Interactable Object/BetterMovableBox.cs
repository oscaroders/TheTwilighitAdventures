using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterMovableBox : ActiveInteractableObject
{
    private bool moving;
    [SerializeField] private GameObject inputController;
    private PlayerInput playerInput;
    private Transform[] players = new Transform[2];
    private Transform startParent;
	void Start ()
    {
        startParent = transform.parent;
        playerInput = inputController.GetComponent<PlayerInput>();
        Interact[] temporary;
        temporary = inputController.GetComponentsInChildren<Interact>();
        players[0] = temporary[0].gameObject.transform;
        players[1] = temporary[1].gameObject.transform;
	}
	void Update ()
    {
		if(moving)
        {
            if (playerInput.IsEveInFocus)
                transform.parent = players[0];
            else
            {
                transform.parent = players[1];
            }
        }
        else
        {
            transform.parent = startParent;
        }
	}
    public override void Interact(bool interacting)
    {
        if(interacting)
        {
            moving = true;
            playerInput.notInteracting = false;
        }
        else
        {
            moving = false;
            playerInput.notInteracting = true;
        }
    }
}