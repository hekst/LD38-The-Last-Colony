using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType {
	FoodAndWater,
	Oxygen,
	People
}

public static class ResourceTypeMethod {

	static Dictionary <ResourceType, float> unloadRatePerSec;

	static ResourceTypeMethod () {
		unloadRatePerSec = new Dictionary<ResourceType, float> ();

		unloadRatePerSec.Add (ResourceType.FoodAndWater, 		5.0f);
		unloadRatePerSec.Add (ResourceType.Oxygen, 				2.0f);
		unloadRatePerSec.Add (ResourceType.People, 				1.0f);
	}

	public static float GetUnloadRatePerSec (this ResourceType resource) {
		return unloadRatePerSec [resource];
	}

}