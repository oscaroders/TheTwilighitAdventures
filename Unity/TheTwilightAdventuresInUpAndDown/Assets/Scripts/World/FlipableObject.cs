using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipableObject : MonoBehaviour {

    public bool isFlippable;
    public Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
    }

    public void SetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}
