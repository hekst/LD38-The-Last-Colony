using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceMeter : MonoBehaviour {

	public RectTransform valueBarRect;
	public float valueBarBuffer = 2.0f;

	RectTransform myRect;
	float meterShellHeight;
	float valueBarMaxHeight;

	void Start () {
		myRect = gameObject.GetComponent <RectTransform> ();
		GetMeterHeight ();

		UpdateValueBar (80.0f);
	}

	void GetMeterHeight () {
		meterShellHeight = myRect.rect.height;
		valueBarMaxHeight = meterShellHeight - (valueBarBuffer * 2);
		Debug.Log ("ResourceMeter shell height: " + meterShellHeight);
		Debug.Log ("ResourceMeter value max height: " + valueBarMaxHeight);
	}

	public void UpdateValueBar (float newPercent) {
		if (newPercent > 100) {
			newPercent = 100;
		} else if (newPercent < 0) {
			newPercent = 0;
		}

		float newTopBuffer = (100 - newPercent) / 100 * valueBarMaxHeight + valueBarBuffer;
		valueBarRect.offsetMax = new Vector2(valueBarRect.offsetMax.x, -newTopBuffer);

		Debug.Log ("ResourceMeter new value height: " + newTopBuffer);

	}


}
