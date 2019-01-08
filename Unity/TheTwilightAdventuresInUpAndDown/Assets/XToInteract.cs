using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XToInteract : MonoBehaviour {

    public PlayerController player;
    public GameObject leaver;
    Text text;
    Image image;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        image = GetComponentInChildren<Image>();
        text.enabled = false;
        image.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(leaver.transform.position, player.transform.position);

        if (distance < 2) {
            text.enabled = true;
            image.enabled = true;
        } else {
            text.enabled = false;
            image.enabled = false;
        }
	}
}
