using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motherland : MonoBehaviour {

	Rigidbody mlRigidbody;
	MotherlandResources resources;

	public DamageReportControl dmgRpt;


	public float maxVelocityTolerated = 1.0f;

	// Use this for initialization
	void Start () {
		mlRigidbody = gameObject.GetComponent<Rigidbody> ();
		resources = gameObject.GetComponent<MotherlandResources> ();
	}
	
	// Update is called once per frame
	void Update () {
		//CheckMomentum ();
	}

	public bool AddResources (ResourceType r, float quantity) {
		return resources.AddToResources (r, quantity);
	}

	public void AddForceToMotherland (Vector3 force) {
		mlRigidbody.AddForce (force);
	}

	void OnCollisionEnter (Collision other) {
		if (other.transform.CompareTag ("CargoShip")
			&& other.relativeVelocity.magnitude > maxVelocityTolerated) {
			//Debug.Log ("THE IMPACT FROM SHIP WAS INCREDIBLE!!" + other.relativeVelocity.magnitude);
			int damageOffset = Random.Range (0, 3);
			DamageRandomResources (other.relativeVelocity.magnitude + damageOffset);
		}
	}

	void DamageRandomResources (float magnitude) {
		int numType = System.Enum.GetNames (typeof (ResourceType)).Length;
		int rand = Random.Range (0, numType);
		ResourceType damagedResource = (ResourceType)rand;

		dmgRpt.UpdateDamageReport (damagedResource, "-" + ((int)magnitude).ToString ());


		// TODO Adjust collision damage here
		AddResources (damagedResource, -magnitude);
	}
}
