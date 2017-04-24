using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScreenState : IShipState {

	Ship ship;
	Vector2 stepSize;

	public ExitScreenState (Ship ship) : base (ship) {
		this.ship = ship;
	}

	public override void EnterState ()
	{
		stepSize = MoveUtil.CalculateStepSize (50, ship.transform.position, ship.startPos, "");
		// Player no longer has control of the ship. Pulling down objective text here.
		// Resetting its momentum
		ship.shipRigidbody.velocity = Vector3.zero;
		ship.warningLight.gameObject.SetActive (false);

		UIManager.manager.SetupStationStatus (ship.dockingStationId, ship.undockingAndReturningStatusMsg + ship.shipName);
	}

	public override void ExitState ()
	{
		UIManager.manager.ResetStationInfo (ship.dockingStationId);
	}

	public override void Update ()
	{
		if (ship.IsShipAtExitPos ()) {
			ship.StateTransitionTo (ship.idleState);
		} else {
			MoveUtil.MoveByStepSizeToDest (ship.transform, ship.exitPos, stepSize, "");
		}
	}


}
