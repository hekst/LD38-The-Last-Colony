using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveUtil {

	/// <summary>
	/// Calculates the size of the step.
	/// </summary>
	/// <returns>The step size in Vector2.</returns>
	/// <param name="granularity">Granularity of the steps on x and y axis.</param>
	/// <param name="origin">Origin coordinate.</param>
	/// <param name="destination">Destination coordinate.</param>
	/// <param name="callerName">[Optional] Caller name for debugging message.</param>
	public static Vector2 CalculateStepSize (int granularity, Vector3 origin, Vector3 destination, string callerName = "") {
		float stepSizeX = (destination.x - origin.x) / granularity;
		float stepSizeY = (destination.y - origin.y) / granularity;
		//Debug.Log ("[MoveUtil] " + callerName + " Granularity: " + granularity);
		//Debug.Log ("[MoveUtil] " + callerName + " Origin: " + origin + " Destination: " + destination);
		//Debug.Log ("[MoveUtil] " + callerName + " Calculated Step Size: " + stepSizeX + ", " + stepSizeY);
		return new Vector2 (stepSizeX, stepSizeY);
	}

	/// <summary>
	/// Moves the transform by step size to destination. Expected to be called during Update () of Monobehaviour.
	/// </summary>
	/// <param name="moverTransform">Mover's transform.</param>
	/// <param name="destination">Destination.</param>
	/// <param name="stepSize">Step size.</param>
	/// <param name="callerName">Caller name.</param>
	public static void MoveByStepSizeToDest (Transform moverTransform, Vector3 destination, Vector2 stepSize, string callerName = "") {
		Vector3 currentPosition = moverTransform.position;
		Vector3 nextPosition = new Vector3 (currentPosition.x + stepSize.x, currentPosition.y + stepSize.y, currentPosition.z);
		if ((nextPosition.x > destination.x && stepSize.x > 0) || (nextPosition.x < destination.x && stepSize.x < 0)) {
			nextPosition.x = destination.x;
		}
		if ((nextPosition.y > destination.y && stepSize.y > 0) || (nextPosition.y < destination.y && stepSize.y < 0)) {
			nextPosition.y = destination.y;
		}
		moverTransform.position = nextPosition;
	}

}
