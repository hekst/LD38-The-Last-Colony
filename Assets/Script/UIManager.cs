using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager manager;

	public Text [] stationInfoShipName;
	public Text [] stationInfoCargoType;
	public Text [] stationInfoQuantity;
	public Text [] stationStatus;


	void Awake () {
		if (manager == null) {
			manager = this;
		} else {
			Destroy (gameObject);
		}
			
		for (int i = 0; i < stationStatus.Length; i++) {
			ResetStationInfo (i);
		}

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void SetupStationInfo (int stationId, Ship ship) {
		if (stationId < 0 || stationId >= 4) {
			Debug.LogError ("UI Manager: SetupStationInfo Rogue StationId provided: " + stationId);
			return;
		}
			
		stationInfoShipName [stationId].text 	= ship.GetShipName ();
		stationInfoCargoType [stationId].text 	= ship.GetShipResourceType ().ToString ();
		stationInfoQuantity [stationId].text 	= ((int)ship.GetShipResourceQuantity ()).ToString ();

		SetupStationStatus (stationId, "Incoming cargo...");
	}
	public void UpdateStationInfoQuantity (int stationId, Ship ship) {
		if (stationId < 0 || stationId >= 4) {
			Debug.LogError ("UI Manager: SetupStationInfo Rogue StationId provided: " + stationId);
			return;
		}

		stationInfoQuantity [stationId].text 	= ((int)ship.GetShipResourceQuantity ()).ToString ();

	}

	public void SetupStationStatus (int stationId, string status) {
		stationStatus [stationId].text = status;
	}

	public void ResetStationInfo (int stationId) {
		stationInfoShipName [stationId].text = "";
		stationInfoCargoType [stationId].text = "";
		stationInfoQuantity [stationId].text = "";

		stationStatus [stationId].text = "Standing by...";
	}
}
