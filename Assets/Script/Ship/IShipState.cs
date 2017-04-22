using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IShipState {

	public Ship ship;

	public IShipState (Ship ship) {
		this.ship = ship;
	}

	public virtual void Update () {

	}

	public virtual void EnterState () {

	}

	public virtual void ExitState () {

	}

}
