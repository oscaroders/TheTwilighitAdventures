using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlideVolume : MonoBehaviour {

    Slider slider;
    public EventSystem eventSystem;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (eventSystem.currentSelectedGameObject == gameObject) {
            if(Input.GetAxisRaw("Horizontal") != 0) {
                slider.value += Input.GetAxisRaw("Horizontal");
            }
        }
	}
}
