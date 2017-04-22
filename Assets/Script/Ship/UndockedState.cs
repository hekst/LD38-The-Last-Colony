using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndockedState : IShipState {

	public UndockedState (Ship ship) : base (ship) {

	}

	public override void EnterState ()
	{
		UIManager.manager.SetupStationStatus (base.ship.dockingStationId, base.ship.awaitingDockingStatusMsg);
	}

	public override void Update ()
	{
		UpdateShipMovement ();
	}

	void UpdateShipMovement () {
		Vector3 input = CheckMovementUpdate ();
		base.ship.AddForceToShip (GetForce (input));
	}

	Vector3 GetForce (Vector3 direction) {
		return direction * base.ship.shipSpeed;
	}

	Vector3 CheckMovementUpdate () {
		Vector3 movement = new Vector3 (0, 0, 0);

		if (base.ship.GetInputToggleDockKey ()) {
			Debug.Log ("Docking/Undocking the ship.");
			if (base.ship.dockingProbe.DockProbeInRange ()) {
				TryToDock ();
			}
		}
		if (base.ship.GetInputMoveInwardKey ()) {
			//Debug.Log ("Moving ship towards the docking station.");
			movement += base.ship.inDirection;
		}
		if (base.ship.GetInputMoveOutwardKey ()) {
			//Debug.Log ("Moving ship away from the docking station.");
			movement += base.ship.outDirection;
		}

		return movement;
	}


	void TryToDock () {
		base.ship.StateTransitionTo (base.ship.dockedState);
	}

}
