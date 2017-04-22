using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motherland : MonoBehaviour {

	Rigidbody mlRigidbody;

	// Use this for initialization
	void Start () {
		mlRigidbody = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (mlRigidbody.velocity != Vector3.zero) {
			//Debug.Log (rigidbody.velocity);

		}
	}

	public void AddForceToMotherland (Vector3 force) {
		mlRigidbody.AddForce (force);
	}
}
