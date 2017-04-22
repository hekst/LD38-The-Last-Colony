using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motherland : MonoBehaviour {

	Rigidbody mlRigidbody;
	MotherlandResources resources;


	public float maxVelocityTolerated = 1.0f;

	// Use this for initialization
	void Start () {
		mlRigidbody = gameObject.GetComponent<Rigidbody> ();
		resources = gameObject.GetComponent<MotherlandResources> ();
	}
	
	// Update is called once per frame
	void Update () {
		CheckMomentum ();
	}

	public void AddForceToMotherland (Vector3 force) {
		mlRigidbody.AddForce (force);
	}

	// If velocity above threshold, do something. Destroyed resources, people falling off the station..
	void CheckMomentum () {
		if (IsMomentumAboveThreshold ()) {
			Debug.Log ("[Motherland:IsMomentumAboveThreshold] Threshold Crossed!! " + mlRigidbody.velocity);
		}
	}


	bool IsMomentumAboveThreshold () {
		if (mlRigidbody.velocity.x > maxVelocityTolerated
			|| mlRigidbody.velocity.y > maxVelocityTolerated
			|| mlRigidbody.velocity.z > maxVelocityTolerated) {
			return true;
		} else {
			return false;
		}
	}
}
