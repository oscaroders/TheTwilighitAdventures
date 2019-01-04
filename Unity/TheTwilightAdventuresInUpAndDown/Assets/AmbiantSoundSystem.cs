using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiantSoundSystem : MonoBehaviour {

    public AudioSource eveAmbientSound;
    public AudioSource dodoAmbientSound;
    private float eveAmbientDefualtVolume;
    private float dodoAmbientDefualtVolume;
	private float evesVolumeInProcent;
	private float dodosVolumeInProcent;
	private PlayerInput pi;
	// Use this for initialization
	void Start () {
        pi = FindObjectOfType<PlayerInput>();
        eveAmbientDefualtVolume = eveAmbientSound.volume;
        dodoAmbientDefualtVolume = dodoAmbientSound.volume;
		evesVolumeInProcent = eveAmbientDefualtVolume * 0.01f;
		dodosVolumeInProcent = dodoAmbientDefualtVolume * 0.01f;
	}
	
	// Update is called once per frame
	void Update () {
        BackGroundMusic();
		FadeAmbientSound();
	}
    public void BackGroundMusic()
    {
        if (pi.IsEveInFocus && !eveAmbientSound.isPlaying)
        {
            //dodoAmbientSound.Pause();
            eveAmbientSound.Play();
        }
        else if (!pi.IsEveInFocus && !dodoAmbientSound.isPlaying)
        {
            //eveAmbientSound.Pause();
            dodoAmbientSound.Play();
        }
    }

	public void FadeAmbientSound()
	{
		if (pi.IsEveInFocus)
		{
			eveAmbientSound.volume += evesVolumeInProcent;
			if (eveAmbientSound.volume >= eveAmbientDefualtVolume)
			{
				eveAmbientSound.volume = eveAmbientDefualtVolume;
			}

			dodoAmbientSound.volume -= dodosVolumeInProcent;

			if (dodoAmbientSound.volume <= 0)
			{
				dodoAmbientSound.volume = 0;
			}
		}
		else if (!pi.IsEveInFocus)
		{
			dodoAmbientSound.volume += dodosVolumeInProcent;
			if (dodoAmbientSound.volume >= dodoAmbientDefualtVolume)
			{
				dodoAmbientSound.volume = dodoAmbientDefualtVolume;
			}

			eveAmbientSound.volume -= evesVolumeInProcent;

			if (eveAmbientSound.volume <= 0)
			{
				eveAmbientSound.volume = 0;
			}
		}
	}
}
