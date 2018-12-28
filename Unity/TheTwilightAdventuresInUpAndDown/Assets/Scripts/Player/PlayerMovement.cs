using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    PlayerController controller;
    private void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    public void Move (float horizontal, float vertical = 0)
    {
        SetDirectionalInput(new Vector2(horizontal, vertical));
    }


    public void SetDirectionalInput(Vector2 input)
    {
        controller.directionalInput = input;
    }
}
