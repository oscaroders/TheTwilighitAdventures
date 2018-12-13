using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMovement : ActionObject {

    private Vector3 startPos;
    public Transform targetPos;
    public float platformMovingSpeed;
    private bool movingToTarget;
    public bool shallMove;
    private bool activated;

	void Start ()
    {
        startPos = transform.position;
        movingToTarget = true;
	}
	
	void Update ()
    {
        float step = platformMovingSpeed * Time.deltaTime;
        Vector3 offset = targetPos.position - transform.position;

        if (offset.magnitude < 1)
        {
            movingToTarget = false;
        }
        else if (transform.position == startPos)
        {
            movingToTarget = true;
        }

        if (movingToTarget == false && (shallMove || !activated))
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
        }
        else if (movingToTarget && activated)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, step);
        }
	}

    public override void OnActivation(bool activated)
    {
        this.activated = activated;
        movingToTarget = activated;
    }
}
