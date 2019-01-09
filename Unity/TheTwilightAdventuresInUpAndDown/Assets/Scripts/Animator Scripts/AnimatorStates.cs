using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorStates : MonoBehaviour {

    Animator animator;

    bool mainMenu = true;
    bool about = false;
    bool settings = false;
    bool filters = false;
    bool controls = false;
    bool language = false;
    bool audioMenu = false;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        animator.SetBool("mainMenu", true);
        animator.SetBool("about", false);
        animator.SetBool("settings", false);
        animator.SetBool("filters", false);
        animator.SetBool("controls", false);
        animator.SetBool("language", false);
        animator.SetBool("audio", false);
    }

    public void AboutAnimation() {
        about = animator.GetBool("about");
        mainMenu = animator.GetBool("mainMenu");
        animator.SetBool("mainMenu", !mainMenu);
        animator.SetBool("about", !about);
    }    

    public void SettingsAnimation() {
        settings = animator.GetBool("settings");
        mainMenu = animator.GetBool("mainMenu");
        animator.SetBool("mainMenu", !mainMenu);
        animator.SetBool("settings", !settings);
    }

    public void FilterAnimation() {
        filters = animator.GetBool("filters");
        settings = animator.GetBool("settings");
        animator.SetBool("settings", !settings);
        animator.SetBool("filters", !filters);
    }

    public void ControlsAnimation() {
        controls = animator.GetBool("controls");
        settings = animator.GetBool("settings");
        animator.SetBool("settings", !settings);
        animator.SetBool("controls", !controls);
    }

    public void AudioAnimation() {
        audioMenu = animator.GetBool("audio");
        settings = animator.GetBool("settings");
        animator.SetBool("settings", !settings);
        animator.SetBool("audio", !audioMenu);
    }

    public void LanguageAnimation() {
        language = animator.GetBool("language");
        settings = animator.GetBool("settings");
        animator.SetBool("settings", !settings);
        animator.SetBool("language", !language);
    }

    public void LoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void ContinueLoad() {
        SaveManager.data = Save.LoadGame(Save.dataPath);
        if (SaveManager.data.scene != null)
        {
            SceneManager.LoadScene(SaveManager.data.scene);
        }
    }

    public void OnQuit() {
        Application.Quit();
    }
	
}
