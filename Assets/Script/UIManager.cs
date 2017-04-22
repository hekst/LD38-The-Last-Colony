using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager manager;

	public GameObject objectiveWindow;
	private GameObject objectiveTextPrefab;

	public Text [] stationInfo; 
	public Text [] stationStatus;

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


	public void SetupStationInfo (int stationId, Ship ship) {
		if (stationId < 0 || stationId >= 4) {
			Debug.LogError ("UI Manager: SetupStationInfo Rogue StationId provided: " + stationId);
			return;
		}
			
		string display = "Cargo from " + ship.shipName + " with " + ship.GetShipResourceType ().ToString ();
		stationInfo [stationId].text = display;
		SetupStationStatus (stationId, "Incoming cargo...");
	}

	public void SetupStationStatus (int stationId, string status) {
		stationStatus [stationId].text = "Status: " + status;
	}

	public void ResetStationInfo (int stationId) {
		stationInfo [stationId].text = "Station" + (stationId + 1).ToString ();
		stationStatus [stationId].text = "Status: Standing by...";
	}
}
