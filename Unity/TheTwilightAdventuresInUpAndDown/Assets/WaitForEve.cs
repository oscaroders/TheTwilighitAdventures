using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitForEve : MonoBehaviour {

    public PlayerInput playerInput;
    public PlayerController player;
    public PlayerController eve;
    public Transform trans;
    Text text;


    // Use this for initialization
    void Start() {
        text = GetComponent<Text>();

        text.enabled = false;

    }

    // Update is called once per frame
    void Update() {

        if (playerInput.currentRoomId == 2) {
            float distance = Vector3.Distance(trans.position, player.transform.position);
            float distanceEve = Vector3.Distance(trans.position, eve.transform.position);

            if (distanceEve < 3) {
                text.enabled = false;

            } else if (distance < 3 && !playerInput.IsEveInFocus) {
                text.enabled = true;

            } else {
                text.enabled = false;

            }
        }
    }
}
