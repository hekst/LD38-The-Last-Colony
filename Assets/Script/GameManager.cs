using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager manager;

	public SpriteRenderer gameOverScreenDeadPeople;

	public PanelNumberControl dayDisplay;
	float dayLengthInSec = 10.0f;
	int daysPassed = 0;
	int numPeopleDied = 0;

	// Use this for initialization

	void Awake () {
		if (manager == null) {
			manager = this;
		} else {
			Destroy (gameObject);
		}
	}

	void Start () {
		InitializeDays ();
		StartCoroutine (CountDays ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void InitializeDays () {
		dayLengthInSec = 2.0f;
		daysPassed = 0;
		numPeopleDied = 0;
	}

	void PassADay () {
		daysPassed++;
		dayDisplay.SetPanelNumber (daysPassed);
	}
	IEnumerator CountDays () {
		yield return new WaitForSeconds (dayLengthInSec);
		PassADay ();

		StartCoroutine (CountDays ());
	}
		
	public void AddToDeadPeopleCount (int num) {
		numPeopleDied += num;
		Debug.Log ("Dead People Count: " + numPeopleDied);
	}

	public int GetDeadPeopleCount () {
		return numPeopleDied;
	}

	public int GetNumDaysPassed () {
		return daysPassed;
	}


	public void InitiateGameOverScreen () {
		gameOverScreenDeadPeople.gameObject.SetActive (true);
		StartCoroutine (WaitSecondsAndLoadMainMenu ());
	}

	IEnumerator WaitSecondsAndLoadMainMenu () {

		yield return new WaitForSeconds (2f);
		SharedSceneManager.manager.LoadMainMenu ();
	}


}
