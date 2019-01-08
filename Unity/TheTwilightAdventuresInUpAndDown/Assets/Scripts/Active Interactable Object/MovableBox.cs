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
	public AudioSource moveBoxSound;

    private void Start()
    {
        box = GetComponent<FixedJoint2D>();
        xPos = transform.position.x;
        boxRB = GetComponent<Rigidbody2D>();
        input = inputController.GetComponent<PlayerInput>();
        playerRigidbody2D = inputController.GetComponentsInChildren<Rigidbody2D>();
        characterSwitch = inputController.GetComponent<CharacterSwitch>();
        SortPlayerRigidbody2DArray();
        
    }
    public override void Interact(bool interacting)
    {
        if (interacting)
		{
			moving = true;
            input.notInteracting = false;
        }
        else
		{
			moving = false;
            input.notInteracting = true;
        }
    }
    private void FixedUpdate()
    {
        if (moving)
		{
            box.connectedBody = playerRigidbody2D[GetIndex()];
            xPos = transform.position.x;
            gameObject.layer = 8;
            boxRB.mass = boxMassMoving;

			if (Input.GetAxis("Horizontal") != 0 && !moveBoxSound.isPlaying)
			{
				moveBoxSound.Play();
			}
			else if (Input.GetButtonUp("Submit"))
			{
				moveBoxSound.Stop();
			}
        }
        else
        {
            
            transform.position = new Vector3(xPos, transform.position.y, 0);
            gameObject.layer = 9;
            boxRB.mass = boxMassStop;
        }
        box.enabled = moving;
    }
    int GetIndex()
    {
        if (characterSwitch.isEve)
            return 0;
        else
            return 1;

    }
    void SortPlayerRigidbody2DArray()
    {
        if(playerRigidbody2D[0].gravityScale < 0)
        {
            Rigidbody2D temporary = playerRigidbody2D[0];
            playerRigidbody2D[0] = playerRigidbody2D[1];
            playerRigidbody2D[1] = temporary;
        }
    }
}