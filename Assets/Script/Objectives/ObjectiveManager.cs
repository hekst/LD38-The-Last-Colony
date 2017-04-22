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
		StartCoroutine (TestSailOut ());
	}

	IEnumerator TestSailOut () {
		yield return new WaitForSeconds (2.0f);
		SetOutOxygenShip ();
	}

	public void AddAvailableShip (Ship ship) {
		listAvailableShips.Add (ship);
	}

	void SetOutOxygenShip () {
		SetupShipAndSailItOut (
			ResourceType.Oxygen,
			AssignNumOxygen ()
		);
	}

	void SetupShipAndSailItOut (ResourceType resource, float resourceQuantity) {
		Ship ship = GetAvailableShip ();
		// No ship available.
		if (ship == null) {
			return;
		}

		// Setup Ship
		ship.SetShipName (GetNameOfShip ());
		ship.SetShipResourceType (resource);
		ship.SetShipResourceQuantity (resourceQuantity);


		// Sail it out
		ship.SailOutShip ();
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

	// Assign resource quantity
	float AssignNumFoodAndWater () {
		return Random.Range (15.0f, 25.0f);
	}

	float AssignNumOxygen () {
		return Random.Range (10.0f, 15.0f);
	}

	float AssignNumPeople () {
		return Random.Range (30.0f, 50.0f);
	}

}
