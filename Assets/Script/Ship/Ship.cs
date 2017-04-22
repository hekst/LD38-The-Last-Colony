using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	// Ship States
	IShipState currentState;
	[HideInInspector] public IdleState idleState;
	[HideInInspector] public EnterScreenState enterScreenState;
	[HideInInspector] public ExitScreenState exitScreenState;
	[HideInInspector] public UndockedState undockedState;
	[HideInInspector] public DockedState dockedState;

	public Rigidbody shipRigidbody;

	public KeyCode moveInwardKey = KeyCode.D;
	public KeyCode moveOutwardKey = KeyCode.A;
	public KeyCode toggleDockKey = KeyCode.F;

	// To initialize in the inspector.
	public Vector3 inDirection;
	public Vector3 outDirection;
	public float shipSpeed;

	public Motherland motherland;
	public DockingProbe dockingProbe;

	public Vector3 startPos;
	public Vector3 exitPos;
	[HideInInspector] public bool docked;

	// Ship Info
	[HideInInspector] public string shipName;
	[HideInInspector] private ResourceType resourceType;
	[HideInInspector] private float resourceQuantity;


	// Use this for initialization
	void Start () {
		shipRigidbody = gameObject.GetComponent <Rigidbody> ();

		docked = false;

		InitializeStates ();
	}

	// Update is called once per frame
	void Update () {
		currentState.Update ();
	}


	void InitializeStates () {
		idleState = new IdleState (this);
		enterScreenState = new EnterScreenState (this);
		exitScreenState = new ExitScreenState (this);
		undockedState = new UndockedState (this);
		dockedState = new DockedState (this);

		currentState = idleState;
		Debug.Log ("Ship's initial state: " + currentState.ToString ());

		currentState.EnterState ();
	}

	public void StateTransitionTo (IShipState newState) {
		currentState.ExitState ();
		currentState = newState;
		currentState.EnterState ();

		// If transitioning to Idle State, let ObjectiveManager know.
		if (IsInIdleState ()) {
			ObjectiveManager.manager.AddAvailableShip (this);
		}
	}

	public bool IsInIdleState () {
		return currentState.ToString () == idleState.ToString ();
	}

	// Control
	public bool GetInputToggleDockKey () {
		return Input.GetKeyUp (toggleDockKey);
	}

	public bool GetInputMoveInwardKey () {
		return Input.GetKey (moveInwardKey);
	}

	public bool GetInputMoveOutwardKey () {
		return Input.GetKey (moveOutwardKey);
	}

	// Movement
	public void AddForceToShip (Vector3 force) {
		shipRigidbody.AddForce (force);
	}

	// Ship Position
	public bool IsShipAtStartPos () {
		return gameObject.transform.position == startPos;
	}
	public bool IsShipAtExitPos () {
		return gameObject.transform.position == exitPos;
	}


	// Interfacing with ObjectiveManager
	public void SetShipName (string newName) {
		if (IsInIdleState () == false) {
			Debug.Log ("!!Ship Trying to change ship info while not in idle state!!");
		}
		shipName = newName;
	}

	public ResourceType GetShipResourceType () {
		return resourceType;
	}

	public void SetShipResourceType (ResourceType rt) {
		if (IsInIdleState () == false) {
			Debug.Log ("!!Ship Trying to change ship info while not in idle state!!");
		}
		resourceType = rt;
	}

	public float GetShipResourceQuantity () {
		return resourceQuantity;
	}

	public void SetShipResourceQuantity (float q) {
		if (q < 0) {
			q = 0;
		}
		resourceQuantity = q;
	}

	public void SailOutShip () {
		Debug.Log (shipName + " sailing out with " + resourceQuantity + " " + resourceType.ToString () + ".");
		if (IsInIdleState () == false) {
			Debug.LogError ("Ship:SailOutShip Trying to send out a ship that's already out!");
			return;
		} else {
			StateTransitionTo (enterScreenState);
		}
	}

	//
	// Unloading System
	public void StartUnloading () {
		Debug.Log (shipName + " started unloading " + resourceType);
		StartCoroutine (UnloadEverySecond ());
	}

	// Unload every second
	IEnumerator UnloadEverySecond () {
		yield return new WaitForSeconds (1.0f);
		float quantity = GetShipResourceQuantity ();
		float unloadRate = GetShipResourceType ().GetUnloadRatePerSec ();
		if ((quantity > 0) && (docked == true)) {
			SetShipResourceQuantity (quantity - unloadRate);
			motherland.AddResources (resourceType, unloadRate);
			StartCoroutine (UnloadEverySecond ());
		} else {
			Debug.Log (shipName + " either finished unloading or undocked while unloading. Remaining resource amount: " + resourceQuantity);
		}
	}

}
