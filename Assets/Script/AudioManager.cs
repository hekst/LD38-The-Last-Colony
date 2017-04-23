using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

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
		Debug.Log ("Insert sound here.");
	}

}
