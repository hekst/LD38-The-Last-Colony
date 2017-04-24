using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterScreenState : IShipState {

	Ship ship;
	Vector2 stepSize;

	public EnterScreenState (Ship ship) : base (ship) {
		this.ship = ship;
	}

	public override void EnterState ()
	{
		if (ship.IsShipAtExitPos () == false) {
			Debug.Log ("Ship:EnterScreenState Ship is not at Exit Position when it is expected! Do check!");
			ship.transform.position = ship.exitPos;
		}
		stepSize = MoveUtil.CalculateStepSize (50, ship.transform.position, ship.startPos, "");
		UIManager.manager.SetupStationInfo (this.ship.dockingStationId, this.ship);
		base.ship.invisibleGate.SetActive (false);
		ship.warningLight.gameObject.SetActive (false);


	}

	public override void ExitState ()
	{
		// TODO this needs to feed into a UI.
		string objective = ship.GetShipName () + " requesting to dock at station " + ship.dockingStationId + ". " + ship.GetShipResourceQuantity ().ToString () + " " + ship.GetShipResourceType ().ToString () + " on board.";
	}

	public override void Update ()
	{
		if (ship.IsShipAtStartPos ()) {
			ship.StateTransitionTo (ship.undockedState);
		} else {
			MoveUtil.MoveByStepSizeToDest (ship.transform, ship.startPos, stepSize, "");
		}
	}




}
