using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipableObject : MonoBehaviour {

    public bool isFlippable;
    public Vector3 startPosition;
    public Quaternion startRotation;
    public Vector3 endPosition;
    public Quaternion endRotation;
    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void SetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
    public void SetEndPosition(Vector3 position, Quaternion rotation)
    {

        endPosition = startPosition;
        endPosition.y = position.y;
        endRotation = rotation;
    }

    public void SetStartPosition(Vector3 position, Quaternion rotation)
    {
        startPosition = position;
        startRotation = rotation;
    }
    public void GoToStart()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
    public void GoToEnd()
    {
        transform.position = endPosition;
        transform.rotation = endRotation;
    }
    
}
