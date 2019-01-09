using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class MenuCameraController : MonoBehaviour {

    AnimatorStates animatorStates;
    Animator animator;

    public GameObject mainMenu;
    public GameObject filterButton;
    public GameObject controlsButton;
    public GameObject languageButton;
    public GameObject audioButton;

    public EventSystem eventSystem;

    public AudioMixer audioMixer;

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
                eventSystem.SetSelectedGameObject(mainMenu);
            }
            if (animator.GetBool("filters")) {
                animatorStates.FilterAnimation();
                eventSystem.SetSelectedGameObject(filterButton);
            }
            if (animator.GetBool("controls")) {
                animatorStates.ControlsAnimation();
                eventSystem.SetSelectedGameObject(controlsButton);
            }
            if (animator.GetBool("language")) {
                animatorStates.LanguageAnimation();
                eventSystem.SetSelectedGameObject(languageButton);
            }
            if (animator.GetBool("audio")) {
                animatorStates.AudioAnimation();
                eventSystem.SetSelectedGameObject(audioButton);
            }
            if (animator.GetBool("mainMenu")) {
                //animatorStates.Quit();
            }
        }
	}

    public void SetMusicVolume(float volume) {
        audioMixer.SetFloat("musicVolume", volume);
    }

    public void SetDialougeVolume(float volume) {
        audioMixer.SetFloat("dialougeVolume", volume);
    }

    public void SetEffectsVolume(float volume) {
        audioMixer.SetFloat("effectsVolume", volume);
    }
}
