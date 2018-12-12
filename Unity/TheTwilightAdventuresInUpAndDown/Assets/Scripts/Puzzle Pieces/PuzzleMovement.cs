using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMovement : ActionObject {

    private Vector3 startPos;
    public Transform target;
    public float speed;
    private bool moveSideways;
    public bool shallMove;
    private bool state;

	void Start ()
    {
        startPos = transform.position;
        moveSideways = true;
	}
	
	void Update ()
    {
        float step = speed * Time.deltaTime;
        Vector3 offset = target.position - transform.position;

        if (offset.magnitude < 1)
        {
            moveSideways = false;
        }
        else if (transform.position == startPos)
        {
            moveSideways = true;
        }

        if (moveSideways == false && (shallMove || !state))
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
        }
        else if (moveSideways && state)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
	}

    public override void OnActivation(bool activated)
    {
        state = activated;
    }
}
