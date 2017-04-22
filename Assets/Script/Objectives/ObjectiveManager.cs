using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour {

	public static ObjectiveManager manager;

	public List<Ship> listAvailableShips;

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

	void SetupShip () {
		Ship ship = GetAvailableShip ();
		// No ship available.
		if (ship == null) {
			return;
		}

		// Setup Ship
		ship.name = GetNameOfShip ();


	}

	Ship GetAvailableShip () {
		Ship retShip;
		if (listAvailableShips.Count <= 0) {
			Debug.Log ("ObjectiveManager:GetAvailableShip No ship available.");
			retShip = null;
		} else {
			int index = Random.Range (0, listAvailableShips.Count);
			retShip = listAvailableShips [index];
			listAvailableShips.RemoveAt (index);
		}
		return retShip;
	}



	string GetNameOfShip () {
		return "Albatross";
	}

}
