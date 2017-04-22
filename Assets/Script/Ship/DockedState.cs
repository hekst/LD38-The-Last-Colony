using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockedState : IShipState {

	float dockingImpact = 10.0f;

	public DockedState (Ship ship) : base (ship) {

	}


	public override void EnterState ()
	{
		base.ship.docked = true;
		Debug.Log (base.ship.gameObject.transform.name + " docked.");
		base.ship.gameObject.transform.parent = base.ship.motherland.gameObject.transform;

		HaltShipAndTransferMomentum ();
	}



	public override void ExitState ()
	{
		Undock ();
	}

	public override void Update ()
	{
		if (base.ship.GetInputToggleDockKey ()) {
			base.ship.StateTransitionTo (base.ship.undockedState);
		}
		// TODO If player tries to move the ship, play a beep indicating they can't while docked.
	}

	// When docking
	// Ship stops moving but remaining kinetic energy will still be transfered
	// to the motherland. You have to be gentle when docking.
	void HaltShipAndTransferMomentum () {
		base.ship.motherland.AddForceToMotherland (base.ship.shipRigidbody.velocity * dockingImpact);
		base.ship.shipRigidbody.velocity = Vector3.zero;
	}


	// When undocking
	void Undock () {

		base.ship.docked = false;
		Debug.Log (base.ship.gameObject.transform.name + " undocked.");
		base.ship.gameObject.transform.parent = null;

		PushShipOutwards ();

	}

	void PushShipOutwards () {
		base.ship.AddForceToShip (base.ship.outDirection * dockingImpact);
	}

}
