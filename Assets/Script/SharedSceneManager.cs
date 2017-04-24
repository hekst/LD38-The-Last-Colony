using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SharedSceneManager : MonoBehaviour {

	/// <summary>
	/// Scene Manager will never be destroyed. Will be shared among scenes.
	/// If information should be passed on to another scene, this will be used to carry it around.
	/// </summary>

	int prevGameNumberOfDaysPassed = 0;
	int prevGameNumberOfDeadPeople = 0;


	public static SharedSceneManager manager;

	void Awake () {
		if (manager == null) {
			manager = this;
		} else {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void LoadMainMenu () {
		if (GameManager.manager == null) {
			Debug.LogError ("[SharedSceneManager] GameManager is missing !!");
		} else {
			prevGameNumberOfDaysPassed = GameManager.manager.GetNumDaysPassed ();
			prevGameNumberOfDeadPeople = GameManager.manager.GetDeadPeopleCount ();
			Debug.Log ("Returning to main menu - Days Passed: " + prevGameNumberOfDaysPassed + " DeadPeopleCount: " + prevGameNumberOfDeadPeople );
		}


		SceneManager.LoadScene ("MainMenu");
	}

	public void LoadGameScene () {
		SceneManager.LoadScene ("MainScene");


	}

}
