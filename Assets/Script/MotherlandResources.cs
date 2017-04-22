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

	// Use this for initialization
	void Start () {
		InitializeResources (80, 80, 80);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateFoodAndWater (float delta) {
		delta += foodAndWater;
		if (delta > foodAndWaterCapacity) {
			delta = foodAndWaterCapacity;
		} else if (delta < 0) {
			delta = 0;
		}
		this.foodAndWater = delta;
	}

	public void UpdateOxygen (float delta) {
		float ox = delta + oxygen;
		if (ox > oxygenCapacity) {
			ox = oxygenCapacity;
		} else if (ox < 0) {
			ox = 0;
		}
		this.oxygen = ox;
	}

	public void UpdatePopulation (float delta) {
		float pop = delta + population;
		if (pop > populationCapacity) {
			pop = populationCapacity;
		} else if (pop < 0) {
			pop = 0;
		}
		this.population = pop;
	}

	void InitializeResources (float fw, float ox, float pop) {
		if (fw > foodAndWaterCapacity) {
			fw = foodAndWaterCapacity;
		} else if (fw < 0) {
			fw = 0;
		}
		this.foodAndWater = fw;

		if (ox > oxygenCapacity) {
			ox = oxygenCapacity;
		} else if (ox < 0) {
			ox = 0;
		}
		this.oxygen = ox;

		if (pop > populationCapacity) {
			pop = populationCapacity;
		} else if (pop < 0) {
			pop = 0;
		}
		this.population = pop;
	}


}
