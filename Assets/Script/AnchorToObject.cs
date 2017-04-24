using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorToObject : MonoBehaviour {

	public GameObject host;
	public bool isAnchorEnabled = true;
	public Vector3 offset;

	// Update is called once per frame
	void Update () {
		if (isAnchorEnabled) {
			gameObject.transform.position = host.transform.position + offset;
		}
	}

	public void EnableAnchor () {
		isAnchorEnabled = true;
	}

	public void EnableAnchorWithNewOffset (Vector3 newOffset) {
		offset = newOffset;
		isAnchorEnabled = true;
	}

	// Offset is calculated at the moment of enable.
	public void EnableAnchorWithCurrentPositionOffset () {
		Vector3 newOffset = new Vector3 (
			gameObject.transform.position.x - host.transform.position.x,
			gameObject.transform.position.y - host.transform.position.y,
			gameObject.transform.position.z - host.transform.position.z
		);

		offset = newOffset;
		//Debug.Log ("[AnchorToObject] New Offset Calculated: " + newOffset);
		isAnchorEnabled = true;
	}

	public void DisableAnchor () {
		isAnchorEnabled = false;
	}

}
