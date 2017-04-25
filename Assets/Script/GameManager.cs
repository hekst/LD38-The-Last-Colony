using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager manager;

	public GameObject gameOverScreenDeadPeople;
	public Text gameOverDaysPassed;
	public Text gameOverNumDeadPeople;


	public PanelNumberControl dayDisplay;
	float dayLengthInSec = 10.0f;
	int daysPassed = 0;
	int numPeopleDied = 0;
	bool hasGameEnded = false;

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
		hasGameEnded = false;

	}

	void PassADay () {
		daysPassed++;
		dayDisplay.SetPanelNumber (daysPassed);
	}
	IEnumerator CountDays () {
		yield return new WaitForSeconds (dayLengthInSec);
		if (hasGameEnded == false) {
			PassADay ();
			StartCoroutine (CountDays ());
		}

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
		hasGameEnded = true;

		gameOverDaysPassed.text = daysPassed.ToString ();
		gameOverNumDeadPeople.text = numPeopleDied.ToString ();

		gameOverScreenDeadPeople.SetActive (true);
		//StartCoroutine (WaitSecondsAndLoadMainMenu ());
	}

	IEnumerator WaitSecondsAndLoadMainMenu () {

		yield return new WaitForSeconds (2f);
		SharedSceneManager.manager.LoadMainMenu ();
	}

	public void ShowHelpScreen () {
		Debug.LogError ("Need to show help screen");
	}


}
