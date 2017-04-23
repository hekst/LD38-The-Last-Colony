using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndockedState : IShipState {

	public UndockedState (Ship ship) : base (ship) {

	}

	public override void EnterState ()
	{
		UIManager.manager.SetupStationStatus (base.ship.dockingStationId, base.ship.awaitingDockingStatusMsg);
		base.ship.invisibleGate.SetActive (true);
	}
	public override void ExitState ()
	{
		base.ship.invisibleGate.SetActive (false);
	}
	public override void Update ()
	{
		UpdateShipMovement ();
		CheckInputAndPlayEffects ();
	}

	void CheckInputAndPlayEffects () {
		if ( Input.GetKeyDown (base.ship.moveInwardKey)) {
			StartMoveInShipEffect ();
		} else if (Input.GetKeyUp (base.ship.moveInwardKey)) {
			StopMoveInShipEffect ();
		}
		if (Input.GetKeyDown (base.ship.moveOutwardKey)) {
			StartMoveOutShipEffect ();
		} else if (Input.GetKeyUp (base.ship.moveOutwardKey)) {
			StopMoveOutShipEffect ();
		}
	}

	public override void OnCollisionEnter (Collision other)
	{
		Debug.Log ("Ship " + base.ship.shipName + " collided with " + other.transform.name);
		//CheckMomentum ();
		if (other.transform.CompareTag ("Motherland") 
			&& other.relativeVelocity.magnitude > base.ship.maxVelocityTolerated) {
			Debug.Log ("THE IMPACT WAS INCREDIBLE! " + other.relativeVelocity.magnitude);
			base.ship.DamageCargo (other.relativeVelocity.magnitude);
			// If all cargo lost in collision, just undock.
			if (base.ship.GetShipResourceQuantity () < 1) {
				base.ship.StateTransitionTo (base.ship.exitScreenState);
			}
			PlayCollisionEffect ();
			base.ship.dmgReportText.UpdateDamageReport (base.ship.GetShipResourceType (), "-" + ((int)other.relativeVelocity.magnitude).ToString ());
		}
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

	void StartMoveInShipEffect () {
		AudioManager.manager.StartPlayShipThruster ();

		base.ship.inArrowActive.SetActive (true);

	}

	void StopMoveInShipEffect () {
		AudioManager.manager.StopPlayShipThruster ();

		base.ship.inArrowActive.SetActive (false);
	}

	void StartMoveOutShipEffect () {
		AudioManager.manager.StartPlayShipThruster ();
		base.ship.outArrowActive.SetActive (true);
	}

	void StopMoveOutShipEffect () {
		AudioManager.manager.StopPlayShipThruster ();
		base.ship.outArrowActive.SetActive (false);
	}

	void PlayCollisionEffect () {
		AudioManager.manager.PlayShipCollision ();



	}

	void TryToDock () {
		base.ship.StateTransitionTo (base.ship.dockedState);

	}

}
