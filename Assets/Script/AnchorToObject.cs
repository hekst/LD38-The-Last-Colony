using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorToObject : MonoBehaviour {

	public GameObject host;
	public Vector3 offset;

	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = host.transform.position + offset;
	}
}
