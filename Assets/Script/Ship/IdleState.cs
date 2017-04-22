using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IShipState {

	public IdleState (Ship ship) : base (ship) {
		this.ship = ship;
	}

	public override void EnterState ()
	{
		// Expected to be resting off screen.
		if (ship.IsShipAtExitPos () == false) {
			ship.transform.position = ship.exitPos;
		}
	}

	// Really does nothing.

}
