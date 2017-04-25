using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour {

	public static ObjectiveManager manager;

	public List<Ship> listAvailableShips;

	public Dictionary<ResourceType, float> deliveryFrequencyBase;
	public Dictionary<ResourceType, float> deliveryFrequencyRange;

	void Awake () {
		if (manager == null) {
			manager = this;
		} else {
			Destroy (gameObject);
		}
		InitializeDeliveryFrequency ();
	}

	// Use this for initialization
	void Start () {
		SetOutOxygenShip ();

		StartCoroutine (TryToDeliverFoodAndWater ());
		StartCoroutine (TryToDeliverOxygen ());
		StartCoroutine (TryToDeliverPeople ());

	}

	//////////////////////////
	// Objective Scheduler ///
	//////////////////////////
	IEnumerator TryToDeliverFoodAndWater () {
		yield return new WaitForSeconds (GetDeliveryFrequency (ResourceType.FoodAndWater));
		Debug.Log ("ObjectiveManager:TryToDeliverFoodAndWater Objective Manager attempting to send out cargo.");
		SetOutFoodAndWaterShip ();

		StartCoroutine (TryToDeliverFoodAndWater ());
	}

	IEnumerator TryToDeliverOxygen () {
		yield return new WaitForSeconds (GetDeliveryFrequency (ResourceType.Oxygen));
		Debug.Log ("ObjectiveManager:TryToDeliverOxygen Objective Manager attempting to send out cargo.");
		SetOutOxygenShip ();

		StartCoroutine (TryToDeliverOxygen ());
	}


	IEnumerator TryToDeliverPeople () {
		yield return new WaitForSeconds (GetDeliveryFrequency (ResourceType.People));
		Debug.Log ("ObjectiveManager:TryToDeliverPeople Objective Manager attempting to send out cargo.");
		SetOutPeopleShip ();

		StartCoroutine (TryToDeliverPeople ());
	}


	// TODO Maybe move this to ResourceTypeMethod. Probably should.
	void InitializeDeliveryFrequency () {
		deliveryFrequencyBase = new Dictionary<ResourceType, float> ();
		deliveryFrequencyBase.Add (ResourceType.FoodAndWater, 	10.0f);
		deliveryFrequencyBase.Add (ResourceType.Oxygen, 		10.0f);
		deliveryFrequencyBase.Add (ResourceType.People, 		15.0f);

		deliveryFrequencyRange = new Dictionary<ResourceType, float> ();
		deliveryFrequencyRange.Add (ResourceType.FoodAndWater, 	6.0f);
		deliveryFrequencyRange.Add (ResourceType.Oxygen, 		6.0f);
		deliveryFrequencyRange.Add (ResourceType.People, 		6.0f);
	}

	// Assign resource quantity
	float AssignNumFoodAndWater () {
		return Random.Range (12.0f, 20.0f);
	}

	float AssignNumOxygen () {
		return Random.Range (8.0f, 14.0f);
	}

	float AssignNumPeople () {
		return Random.Range (10.0f, 50.0f);
	}
		
	float GetDeliveryFrequency (ResourceType r) {
		return Random.Range (
			deliveryFrequencyBase[r] - deliveryFrequencyRange[r],
			deliveryFrequencyBase[r] + deliveryFrequencyRange[r]
		);
	}

	//////////////////////////

	public void AddAvailableShip (Ship ship) {
		listAvailableShips.Add (ship);
	}

	void SetOutOxygenShip () {
		SetupShipAndSailItOut (
			ResourceType.Oxygen,
			AssignNumOxygen ()
		);
	}
	void SetOutFoodAndWaterShip () {
		SetupShipAndSailItOut (
			ResourceType.FoodAndWater,
			AssignNumFoodAndWater ()
		);
	}
	void SetOutPeopleShip () {
		SetupShipAndSailItOut (
			ResourceType.People,
			AssignNumPeople ()
		);
	}

	void SetupShipAndSailItOut (ResourceType resource, float resourceQuantity) {
		Ship ship = GetAvailableShip ();
		// No ship available.
		if (ship == null) {
			return;
		}

		// Setup Ship
		ship.SetShipName (GetNameOfShip (resource));
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

	string GetNameOfShip (ResourceType resourceType) {
		string name;
		if (resourceType == ResourceType.People) {
			name = ShipNames.GetRandomPassengerShipName ();
		} else {
			name = ShipNames.GetRandomCargoShipName ();
		}

		return name;
	}


}
