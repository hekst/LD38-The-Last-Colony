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
	float valueBarMaxWidth;

	void Start () {
		myRect = gameObject.GetComponent <RectTransform> ();
		GetMeterHeight ();

		//UpdateValueBarVertical (80.0f);
	}

	void GetMeterHeight () {
		meterShellHeight = myRect.rect.height;
		valueBarMaxHeight = meterShellHeight - (valueBarBuffer * 2);
		valueBarMaxWidth = myRect.rect.width;
		//Debug.Log ("ResourceMeter shell height: " + meterShellHeight);
		//Debug.Log ("ResourceMeter value max height: " + valueBarMaxHeight);
	}

	public void UpdateValueBarVertical (float newPercent) {
		if (newPercent > 100) {
			newPercent = 100;
		} else if (newPercent < 0) {
			newPercent = 0;
		}

		float newTopBuffer = (100 - newPercent) / 100 * valueBarMaxHeight + valueBarBuffer;
		valueBarRect.offsetMax = new Vector2(valueBarRect.offsetMax.x, -newTopBuffer);

		//Debug.Log ("ResourceMeter new value height: " + newTopBuffer);

	}

	public void UpdateValueBarHorizontal (float newPercent) {
		if (newPercent > 100) {
			newPercent = 100;
		} else if (newPercent < 0) {
			newPercent = 0;
		}

		float newRight = (100 - newPercent) / 100 * valueBarMaxWidth;
		valueBarRect.offsetMax = new Vector2 (-newRight, valueBarRect.offsetMax.y);
	}
}
