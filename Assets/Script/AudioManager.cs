using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource warningSiren;

	public AudioSource meterWarningSound;

	public AudioSource shipThruster;
	public AudioSource shipCrash;
	public AudioSource shipDockedNotification;
	public AudioSource shipReadyToUndockNotification;

	public AudioSource [] listBackgroundMusic;
	AudioSource currentBackgroundMusic;

	public static AudioManager manager;
	// Use this for initialization
	void Awake () {
		if (manager == null) {
			manager = this;
		} else {
			Destroy (gameObject);
		}
	}

	void Start () {

		StartCoroutine (BackgroundMusicManager ());
	}

	IEnumerator BackgroundMusicManager () {
		yield return new WaitForSeconds (5.0f);
		if (currentBackgroundMusic == null) {
			currentBackgroundMusic = GetRandomBackgroundMusic ();
			currentBackgroundMusic.Play ();
		} else if (currentBackgroundMusic.isPlaying == false) {

			currentBackgroundMusic = GetRandomBackgroundMusic ();
			currentBackgroundMusic.Play ();
		}

		StartCoroutine (BackgroundMusicManager ());
	}

	AudioSource GetRandomBackgroundMusic () {
		return listBackgroundMusic [Random.Range (0, listBackgroundMusic.Length)];
	}

	public void PlayMeterWarningLightOn () {
		meterWarningSound.Play ();
	}

	public void StartPlayShipThruster () {
		shipThruster.Play ();
	}
	public void StopPlayShipThruster () {
		shipThruster.Stop ();
	}

	public void PlayShipCollision () {
		shipCrash.Play ();
	}

	public void PlayDockingSound () {
		shipDockedNotification.Play ();

	}

	public void PlayReadyToUndockNoti () {
		shipReadyToUndockNotification.Play ();
	}

	public void PlayUndockingSound () {
		Debug.Log ("Insert sound here");
	}


	public void StartWarningSiren () {
		warningSiren.Play ();
	}

	public void StopWarningSiren () {
		warningSiren.Stop ();
	}
}
