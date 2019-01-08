using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptFlip : MonoBehaviour {

    public PlayerInput playerInput;
    public PlayerController player;
    public Transform trans;
    bool firstTimeHere = true;

    Text text;


    // Use this for initialization
    void Start() {
        text = GetComponent<Text>();

        text.enabled = false;

    }

    // Update is called once per frame
    void Update() {

        if (playerInput.currentRoomId == 2 && playerInput.IsEveInFocus) {
            float distance = Vector3.Distance(trans.position, player.transform.position);

            if (distance < 2.5 && firstTimeHere) {
                text.enabled = true;
                if (Input.GetButton("FlipWorld")) {
                    firstTimeHere = false;
                }

            } else {
                text.enabled = false;

            }
        }
    }
}