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
