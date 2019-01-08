using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptSwitch : MonoBehaviour {

    public PlayerInput playerInput;

    bool showText = true;
    Text text;


    // Use this for initialization
    void Start() {
        text = GetComponent<Text>();

        text.enabled = false;

    }

    // Update is called once per frame
    void Update() {

        if (playerInput.currentRoomId == 2) {

            if (showText && !playerInput.IsEveInFocus) {
                text.enabled = true;
                if (Input.GetButtonDown("CharacterSwitch")) {
                    showText = false;
                }

            } else {
                text.enabled = false;

            }
        }
    }
}