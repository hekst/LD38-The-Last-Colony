﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceMeter : MonoBehaviour {

	public RectTransform valueBarRect;
	public float valueBarBuffer = 2.0f;
	public ParticleSystem warningLightPs;

	RectTransform myRect;
	float meterShellHeight;
	float valueBarMaxHeight;
	float valueBarMaxWidth;

	bool isWarningOn;

	void Start () {
		myRect = gameObject.GetComponent <RectTransform> ();
		GetMeterHeight ();
		WarningLightOff ();
		//UpdateValueBarVertical (80.0f);
	}

	void GetMeterHeight () {
		meterShellHeight = myRect.rect.height;
		valueBarMaxHeight = meterShellHeight - (valueBarBuffer * 2);
		valueBarMaxWidth = myRect.rect.width;
		//Debug.Log ("ResourceMeter shell height: " + meterShellHeight);
		//Debug.Log ("ResourceMeter value max height: " + valueBarMaxHeight);
	}

	public void UpdateValueBarHorizontal (float newPercent) {
		if (newPercent > 100) {
			newPercent = 100;
		} else if (newPercent < 0) {
			newPercent = 0;
		}

		float newRight = (100 - newPercent) / 100 * valueBarMaxWidth;
		valueBarRect.offsetMax = new Vector2 (-newRight, valueBarRect.offsetMax.y);


		if (newPercent < 30 && isWarningOn == false) {
			WarningOn ();
		} else if (newPercent > 36) {
			// There is a buffer to prevent flicker while resources are around the boundary.
			WarningOff ();
		}
	}


	void WarningOn () {
		isWarningOn = true;
		WarningLightOn ();
		AudioManager.manager.PlayMeterWarningLightOn ();
	}

	void WarningOff () {
		isWarningOn = false;
		WarningLightOff ();
	}


	// Control Warning "Light"

	void WarningLightOn () {
		warningLightPs.Play ();
	}

	void WarningLightOff () {
		warningLightPs.Stop ();
	}


}
