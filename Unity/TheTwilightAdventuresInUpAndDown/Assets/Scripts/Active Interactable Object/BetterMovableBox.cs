using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterMovableBox : ActiveInteractableObject
{
    private bool moving;
    [SerializeField] private GameObject inputController;
    internal PlayerInput playerInput;
    private Transform[] players = new Transform[2];
    private Transform startParent;
    private MovableBoxPhysics boxPhysics;

	void Start ()
    {
        boxPhysics = GetComponent<MovableBoxPhysics>();
        startParent = transform.parent;
        playerInput = inputController.GetComponent<PlayerInput>();
        Interact[] temporary;
        temporary = inputController.GetComponentsInChildren<Interact>();
        players[0] = temporary[0].gameObject.transform;
        players[1] = temporary[1].gameObject.transform;
	}
    void Update()
    {
        if (moving)
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

        if (playerInput.evePlayer.velocity.y != 0 || playerInput.dodoPlayer.velocity.y != 0 || boxPhysics.velocity.y != 0 )
        {
            transform.parent = startParent;
            Interact(false);
            players[0].GetComponent<Interact>().InteractObject(false, 0);
            players[1].GetComponent<Interact>().InteractObject(false, 0);
        }

	}
    public override void Interact(bool interacting)
    {
        if(interacting)
        {
            moving = true;
            gameObject.layer = 8;
            playerInput.notInteracting = false;
        }
        else
        {
            moving = false;
            gameObject.layer = 9;
            playerInput.notInteracting = true;
        }
    }
}