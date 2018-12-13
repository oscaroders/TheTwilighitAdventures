using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerPrefsSave : MonoBehaviour {

    private int roomNumber;
    private string sceneName;
    private float lanternFuel;
    private float musicAudioSettings;
    private float dialougueAudioSettings;
    private float effectsAudioSettings;
    private Scene scene;
    public PlayerInput playerInput;
    public LanternControll lanternControll;
    public AudioMixer audioMixer;
    

    void Start()
    {
               
    }

    public void SavePlayer()
    {
        roomNumber = playerInput.currentRoomId;
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

        PlayerPrefs.SetInt("RoomNumber", roomNumber);
        PlayerPrefs.SetString("SceneName", sceneName);
        //PlayerPrefs.SetFloat("LanternFuel", lanternFuel);
    }

    public void SaveSettings()
    {
        audioMixer.GetFloat("musicVolume", out musicAudioSettings);
        audioMixer.GetFloat("dialogueVolume", out dialougueAudioSettings);
        audioMixer.GetFloat("effectsVolume", out effectsAudioSettings);

        PlayerPrefs.SetFloat("MusicVolume", musicAudioSettings);
        PlayerPrefs.SetFloat("DialogueVolume", dialougueAudioSettings);
        PlayerPrefs.SetFloat("EffectsVolume", effectsAudioSettings);

    }

    public void Load()
    {

        playerInput.currentRoomId = PlayerPrefs.GetInt("RoomNumber");
        sceneName = PlayerPrefs.GetString("SceneName");
        //PlayerPrefs.GetFloat("LanternFuel");

        audioMixer.SetFloat("musicVolume",PlayerPrefs.GetFloat("MusicVolume"));
        audioMixer.SetFloat("dialogueVolume", PlayerPrefs.GetFloat("DialogueVolume"));
        audioMixer.SetFloat("effectsVolume", PlayerPrefs.GetFloat("EffectsVolume"));
        SceneManager.LoadScene(sceneName);

    }

    void Update ()
    {
		
	}
}
