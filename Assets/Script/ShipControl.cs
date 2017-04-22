using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour {

	private Rigidbody rigidbody;

	public KeyCode moveInwardKey = KeyCode.D;
	public KeyCode moveOutwardKey = KeyCode.A;
	public KeyCode toggleDockKey = KeyCode.F;

	// To initialize in the inspector.
	public Vector3 inDirection;
	public Vector3 outDirection;
	public float shipSpeed;

	// Use this for initialization
	void Start () {
		rigidbody = gameObject.GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateShipMovement ();
	}

	void UpdateShipMovement () {
		Vector3 input = CheckMovementUpdate ();
		rigidbody.AddForce (GetForce (input));

	}

	Vector3 GetForce (Vector3 direction) {
		return direction * shipSpeed;
	}

	Vector3 CheckMovementUpdate () {
		Vector3 movement = new Vector3 (0, 0, 0);

		if (Input.GetKey (toggleDockKey)) {
			//Debug.Log ("Docking/Undocking the ship.");
		}
		if (Input.GetKey (moveInwardKey)) {
			//Debug.Log ("Moving ship towards the docking station.");
			movement += inDirection;
		}
		if (Input.GetKey (moveOutwardKey)) {
			//Debug.Log ("Moving ship away from the docking station.");
			movement += outDirection;
		}

		return movement;
	}




}
