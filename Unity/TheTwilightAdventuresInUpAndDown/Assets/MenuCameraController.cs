using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraController : MonoBehaviour {

    AnimatorStates animatorStates;
    Animator animator;

	// Use this for initialization
	void Start () {
        animatorStates = GetComponent<AnimatorStates>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Back")) {
            if (animator.GetBool("about")) {
                animatorStates.AboutAnimation();
            }
            if (animator.GetBool("settings")) {
                animatorStates.SettingsAnimation();
            }
            if (animator.GetBool("filters")) {
                animatorStates.FilterAnimation();
            }
            if (animator.GetBool("controls")) {
                animatorStates.ControlsAnimation();
            }
            if (animator.GetBool("language")) {
                animatorStates.LanguageAnimation();
            }
            if (animator.GetBool("audio")) {
                animatorStates.AudioAnimation();
            }
            if (animator.GetBool("mainMenu")) {
                animatorStates.Quit();
            }
        }
	}
}
