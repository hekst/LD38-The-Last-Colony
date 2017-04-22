using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherlandResources : MonoBehaviour {

	float foodAndWaterCapacity = 100;
	float oxygenCapacity = 100;
	float populationCapacity = 100;

	float foodAndWater;
	float oxygen;
	float population;

	public ResourceMeter foodAndWaterMeter;
	public ResourceMeter oxygenMeter;
	public ResourceMeter populationMeter;

	// Use this for initialization
	void Start () {
		InitializeResources (35, 35, 50);

		StartCoroutine (DepleteResourceEverySecond ());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator DepleteResourceEverySecond () {
		yield return new WaitForSeconds (1.0f);
		int numTypes = System.Enum.GetNames (typeof (ResourceType)).Length;
		for (int i = 0; i < numTypes; i++) {
			ResourceType r = (ResourceType)i;
			AddToResources (r, r.GetDepletionRatePerSec ());
		}
		StartCoroutine (DepleteResourceEverySecond ());
	}

	// Return false if resources are at maximum capacity
	public bool AddToResources (ResourceType resource, float delta) {
		bool success = false;
		switch (resource) {
		case ResourceType.FoodAndWater:
			success = UpdateFoodAndWater (foodAndWater + delta);
			break;
		case ResourceType.Oxygen:
			success = UpdateOxygen (oxygen + delta);
			break;
		case ResourceType.People:
			success = UpdatePopulation (population + delta);
			break;
		default:
			Debug.LogError ("MotherlandResources:AddToResources Unknow resource type passed in!! " + resource.ToString ());
			success = false;
			break;
		}
		return success;
	}

	public bool UpdateFoodAndWater (float food) {
		// Update value
		if (food > foodAndWaterCapacity) {
			food = foodAndWaterCapacity;
			return false;
		} else if (food < 0) {
			food = 0;
		}
		this.foodAndWater = food;

		// Update UI
		foodAndWaterMeter.UpdateValueBar (this.foodAndWater);
		return true;
	}

	public bool UpdateOxygen (float ox) {
		// Update value
		if (ox > oxygenCapacity) {
			ox = oxygenCapacity;
			return false;
		} else if (ox < 0) {
			ox = 0;
		}
		this.oxygen = ox;

		// Update UI
		oxygenMeter.UpdateValueBar (this.oxygen);
		return true;
	}

	public bool UpdatePopulation (float pop) {
		// Update value
		if (pop > populationCapacity) {
			pop = populationCapacity;
			return false;
		} else if (pop < 0) {
			pop = 0;
		}
		this.population = pop;

		// Update UI
		populationMeter.UpdateValueBar (this.population);
		return true;
	}

	void InitializeResources (float fw, float ox, float pop) {
		UpdateFoodAndWater (fw);
		UpdateOxygen (ox);
		UpdatePopulation (pop);
	}


}
