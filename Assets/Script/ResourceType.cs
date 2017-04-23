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
	static Dictionary <ResourceType, float> depletionRatePerSec;
	static float mortalityRateStarve 	= -4.0f;
	static float mortalityRateSuffocate = -8.0f;

	static ResourceTypeMethod () {
		unloadRatePerSec = new Dictionary<ResourceType, float> ();

		unloadRatePerSec.Add (ResourceType.FoodAndWater, 		5.0f);
		unloadRatePerSec.Add (ResourceType.Oxygen, 				2.0f);
		unloadRatePerSec.Add (ResourceType.People, 				1.0f);

		depletionRatePerSec = new Dictionary<ResourceType, float> ();

		depletionRatePerSec.Add (ResourceType.FoodAndWater,		-0.5f);
		depletionRatePerSec.Add (ResourceType.Oxygen,			-0.5f);
		depletionRatePerSec.Add (ResourceType.People,			-0.0f);
	}

	public static float GetUnloadRatePerSec (this ResourceType resource) {
		return unloadRatePerSec [resource];
	}

	public static float GetDepletionRatePerSec (this ResourceType resource) {
		return depletionRatePerSec [resource];

	}

	public static float GetMortalityRateStarve (this ResourceType resource) {
		return mortalityRateStarve;
	}

	public static float GetMortalityRateSuffocate (this ResourceType resource) {
		return mortalityRateSuffocate;
	}

}