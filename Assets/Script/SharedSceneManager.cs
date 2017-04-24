using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SharedSceneManager : MonoBehaviour {

	/// <summary>
	/// Scene Manager will never be destroyed. Will be shared among scenes.
	/// If information should be passed on to another scene, this will be used to carry it around.
	/// </summary>


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
		SceneManager.LoadScene ("MainMenu");
	}

	public void LoadGameScene () {
		SceneManager.LoadScene ("MainScene");


	}

}
