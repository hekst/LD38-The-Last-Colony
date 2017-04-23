using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageReportControl : MonoBehaviour {

	Text dmgText;
	float fadeOutRate = 0.01f;
	Dictionary <ResourceType, Color32> resourceColorMap;
	// Use this for initialization
	void Start () {
		dmgText = gameObject.GetComponent <Text> ();
		resourceColorMap = new Dictionary<ResourceType, Color32> ();

		resourceColorMap.Add (ResourceType.FoodAndWater, 	new Color32 (97, 210, 98, 255));
		resourceColorMap.Add (ResourceType.Oxygen, 			new Color32 (88, 163, 249, 255));
		resourceColorMap.Add (ResourceType.People, 			new Color32 (249, 131, 88, 255));
	}

	public void UpdateDamageReport (ResourceType r, string newReport) {
		StopCoroutine (FadeOutText ());
		dmgText.color = resourceColorMap[r];
		dmgText.text = newReport;
		StartCoroutine (FadeOutText ());
	}

	IEnumerator FadeOutText () {
		yield return new WaitForEndOfFrame ();
		if (dmgText.color.a > 0) {
			Color newColor = dmgText.color;
			newColor.a -= fadeOutRate;
			dmgText.color = newColor;

			StartCoroutine (FadeOutText ());
		}

	}
}
