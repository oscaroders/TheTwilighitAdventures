using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiantSoundSystem : MonoBehaviour {

    public AudioSource eveAmbientSound;
    public AudioSource dodoAmbientSound;
    private float eveAmbientDefualtVolume;
    private float dodoAmbientDefualtVolume;
    private PlayerInput pi;
	// Use this for initialization
	void Start () {
        pi = FindObjectOfType<PlayerInput>();
        eveAmbientDefualtVolume = eveAmbientSound.volume;
        dodoAmbientDefualtVolume = dodoAmbientSound.volume;
	}
	
	// Update is called once per frame
	void Update () {
        BackGroundMusic();
	}
    public void BackGroundMusic()
    {
        if (pi.IsEveInFocus && !eveAmbientSound.isPlaying)
        {
            dodoAmbientSound.Pause();
            eveAmbientSound.Play();
        }
        else if (!pi.IsEveInFocus && !dodoAmbientSound.isPlaying)
        {
            eveAmbientSound.Pause();
            dodoAmbientSound.Play();
        }
    }
}
