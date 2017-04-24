﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource warningSiren;

	public AudioSource meterWarningSound;

	public AudioSource shipThruster;
	public AudioSource shipCrash;
	public AudioSource shipDockedNotification;
	public AudioSource shipReadyToUndockNotification;

	public static AudioManager manager;
	// Use this for initialization
	void Awake () {
		if (manager == null) {
			manager = this;
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
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
