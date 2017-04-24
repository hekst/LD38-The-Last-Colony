using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueEventManager : MonoBehaviour {

	public static RogueEventManager manager;

	List<RogueEventInfo> peopleShipEventList;

	void Awake () {
		if (manager == null) {
			manager = this;
		} else {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		InitializeRogueEventList ();
	}


	void InitializeRogueEventList () {
		peopleShipEventList = new List<RogueEventInfo> ();

		peopleShipEventList.Add (new RogueEventInfo (ResourceType.People, -3.0f, "!! CONFUSED ALIEN RAMPAGING !!"));

	}

	public RogueEventInfo GetRandomRogueEvent (ResourceType r) {

		List<RogueEventInfo> eventList = null;

		switch (r) {
		case ResourceType.FoodAndWater:
			break;
		case ResourceType.Oxygen:
			break;
		case ResourceType.People:
			eventList = peopleShipEventList;
			break;
		default:
			break;
		}

		if (eventList == null) {
			return null;
		} else {
			return eventList [Random.Range (0, eventList.Count)];
		}
		// TODO Setup coroutine or something for more effects?
	}
}
