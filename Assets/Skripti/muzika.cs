using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class muzika : MonoBehaviour {
	public Slider volumeSlider;
	public GameObject ObjektuMuzika;

	private float MusicVolume = 0.5f;
	private AudioSource AudioSource;


	 void Start(){
		ObjektuMuzika = GameObject.FindWithTag ("gameMusic");
		AudioSource = ObjektuMuzika.GetComponent<AudioSource>();

		MusicVolume = PlayerPrefs.GetFloat ("volume");
		AudioSource.volume = MusicVolume;
		volumeSlider.value = MusicVolume;
	}


	 void Update(){
		AudioSource.volume = MusicVolume;
		PlayerPrefs.SetFloat ("volume", MusicVolume);
	}

	 void VolumeUpdater(float volume){
		MusicVolume = volume;
	}

	 void MuteUnmute(bool muted){
		Scene tagadejaisScene = SceneManager.GetActiveScene();
		if (!muted) {
			AudioSource.volume = 0f;
			volumeSlider.value = 0f;
		} else {
			AudioSource.volume = 1f;
			volumeSlider.value = 1f;
		}
	}

}
