using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager manager;

	public GameObject objectiveWindow;
	private GameObject objectiveTextPrefab;

	void Awake () {
		if (manager == null) {
			manager = this;
		} else {
			Destroy (gameObject);
		}

		objectiveTextPrefab = Resources.Load ("UIPrefabs/ObjectiveText", typeof(GameObject)) as GameObject;
		if (objectiveTextPrefab == null) {
			Debug.LogError ("UIManager:Awake Failed to load objective text prefab!!");
		}

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject InstantiateObjectiveText (string objective) {
		GameObject objectiveText = Instantiate (objectiveTextPrefab);
		objectiveText.transform.SetParent (objectiveWindow.transform, false);
		objectiveText.GetComponent<Text> ().text = "- " + objective;
		return objectiveText;
	}

	public void DestroyObjectiveText (GameObject obj) {
		Destroy (obj);
	}

}
