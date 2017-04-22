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
		InitializeResources (80, 25, 50);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateFoodAndWater (float food) {
		// Update value
		if (food > foodAndWaterCapacity) {
			food = foodAndWaterCapacity;
		} else if (food < 0) {
			food = 0;
		}
		this.foodAndWater = food;

		// Update UI
		foodAndWaterMeter.UpdateValueBar (this.foodAndWater);
	}

	public void UpdateOxygen (float ox) {
		// Update value
		if (ox > oxygenCapacity) {
			ox = oxygenCapacity;
		} else if (ox < 0) {
			ox = 0;
		}
		this.oxygen = ox;

		// Update UI
		oxygenMeter.UpdateValueBar (this.oxygen);
	}

	public void UpdatePopulation (float pop) {
		// Update value
		if (pop > populationCapacity) {
			pop = populationCapacity;
		} else if (pop < 0) {
			pop = 0;
		}
		this.population = pop;

		// Update UI
		populationMeter.UpdateValueBar (this.population);
	}

	void InitializeResources (float fw, float ox, float pop) {
		UpdateFoodAndWater (fw);
		UpdateOxygen (ox);
		UpdatePopulation (pop);
	}


}
