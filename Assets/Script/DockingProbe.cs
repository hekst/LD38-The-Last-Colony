using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockingProbe : MonoBehaviour {

	public ShipControl ship;

	private bool dockProbeInRange;

	// Use this for initialization
	void Start () {
		dockProbeInRange = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag (TagList.dockingProbe)) {
			Debug.Log ("Docking probe detected other probe " + other.transform.name);
			dockProbeInRange = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.CompareTag (TagList.dockingProbe)) {
			Debug.Log ("Docking probe getting out of range from other probe " + other.transform.name);
			dockProbeInRange = false;
		}
	}

	public bool DockProbeInRange () {
		return dockProbeInRange;
	}

}
