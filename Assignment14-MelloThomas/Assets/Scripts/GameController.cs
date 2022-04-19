using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	private AudioMixer audioMixer;
	private Slider masterVolumeSlider;
	private Slider musicVolumeSlider;
	private Slider soundfxVolumeSlider;

	float master;
	float music;
	float sound;

	void Awake() {
		audioMixer = Resources.Load ("Audio/GameAudioMixer") as AudioMixer;
		masterVolumeSlider = GameObject.Find("MasterVolumeSlider").GetComponent<Slider>();
		musicVolumeSlider = GameObject.Find("MusicVolumeSlider").GetComponent<Slider>();
		soundfxVolumeSlider = GameObject.Find("SoundFXVolumeSlider").GetComponent<Slider>();
	}

	void Start () {
		audioMixer.GetFloat ("masterVolume", out master);
		audioMixer.GetFloat ("musicVolume", out music);
		audioMixer.GetFloat ("soundVolume", out sound);

		Debug.Log ("Master: " + master);
		Debug.Log ("Music: " + music);
		Debug.Log ("SoundFX: " + sound);

		masterVolumeSlider.value = master;
		musicVolumeSlider.value = music;
		soundfxVolumeSlider.value = sound;
	}

	public void ChangeMasterVolumeSlider () {
		audioMixer.SetFloat ("masterVolume", masterVolumeSlider.value);
		// Write to PlayerPrefs if you wanted...
	}
	public void ChangeMusicVolumeSlider()
	{
		audioMixer.SetFloat("musicVolume", musicVolumeSlider.value);
		// Write to PlayerPrefs if you wanted...
	}
	public void ChangeSoundFXVolumeSlider()
	{
		audioMixer.SetFloat("soundVolume", soundfxVolumeSlider.value);
		// Write to PlayerPrefs if you wanted...
	}

	void Update () {
		if (Input.GetKeyUp (KeyCode.F1)) {
			audioMixer.SetFloat ("masterVolume", master -5.0f);
			audioMixer.SetFloat ("musicVolume", music-5.0f);
			audioMixer.SetFloat ("soundVolume", sound -5.0f);
		}
		if (Input.GetKeyUp (KeyCode.F2)) {
			audioMixer.SetFloat ("masterVolume", master +5.0f);
			audioMixer.SetFloat ("musicVolume", music+5.0f);
			audioMixer.SetFloat ("soundVolume", sound +5.0f);
		}
	}
}
