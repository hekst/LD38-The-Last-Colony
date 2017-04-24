using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelNumberControl : MonoBehaviour {

	// Assumes 3 digits.
	public SpriteRenderer [] digits;
	public Sprite[] panelNumbers;
	public Sprite panelNumberOff;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < digits.Length; i++) {
			digits [i].sprite = panelNumbers[0];
		}
	}
	

	public void SetPanelNumber (int num) {
		int digit_1;
		int digit_10;
		int digit_100;

		if (num > 999) {
			digit_1 = 9;
			digit_10 = 9;
			digit_100 = 9;
		} else {
			digit_1 = num % 10;
			digit_10	= (num % 100) / 10;
			digit_100	= (num % 1000) / 100;
		}

		//Debug.Log (digit_100.ToString () + " " + digit_10.ToString () + " " + digit_1.ToString ());
		digits [0].sprite = panelNumbers [digit_1];
		digits [1].sprite = panelNumbers [digit_10];
		digits [2].sprite = panelNumbers [digit_100];

	}

}
