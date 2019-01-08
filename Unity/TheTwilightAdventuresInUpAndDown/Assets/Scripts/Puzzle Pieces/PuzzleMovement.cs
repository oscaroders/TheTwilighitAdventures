using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMovement : ActionObject {

    private Vector3 startPos;
    private Vector3 upStart;
    private Vector3 downStart;
    public Transform targetPos;
    public float platformMovingSpeed;
    private bool movingToTarget, once = true;
    public bool shallMove;
    private bool activated;
    private FlipableObject flipableObject;
    private Transform playerParent;

	void Start ()
    {
        startPos = transform.position;
        flipableObject = GetComponent<FlipableObject>();
        upStart = transform.position;
        downStart = transform.position;

        movingToTarget = true;
        if (gameObject.name.Contains("Remnent"))
        {
            GameObject g = GameObject.Find("Remnent of " + targetPos.name);
            targetPos = g.transform;
            upStart = transform.position;
            downStart = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (playerParent == null)
                playerParent = collision.transform.parent;
            collision.transform.parent = gameObject.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.parent = playerParent;
            playerParent = null;
        }
    }

    void Update ()
    {
        float step = platformMovingSpeed * Time.deltaTime;
        if (flipableObject.isInDown)
        {
            startPos = downStart;
        } else
        {
            startPos = upStart;
        }

        Vector3 offset = targetPos.position - transform.position;

        if (offset.magnitude < 1)
        {
            movingToTarget = false;
        }
        else if (transform.position == startPos)
        {
            movingToTarget = true;
            once = true;
        }
        // Update is on End or Start;
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
        if(activated && once)
        {
            movingToTarget = true;
            once = false;
        }
        else if(!activated)
            movingToTarget = false;
    }
}