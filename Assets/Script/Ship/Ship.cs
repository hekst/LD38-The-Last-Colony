using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour {

	// Ship States
	IShipState currentState;
	[HideInInspector] public IdleState idleState;
	[HideInInspector] public EnterScreenState enterScreenState;
	[HideInInspector] public ExitScreenState exitScreenState;
	[HideInInspector] public UndockedState undockedState;
	[HideInInspector] public DockedState dockedState;

	[HideInInspector] public Rigidbody shipRigidbody;

	public float maxVelocityTolerated = 2.0f;

	public KeyCode moveInwardKey = KeyCode.D;
	public KeyCode moveOutwardKey = KeyCode.A;
	public KeyCode toggleDockKey = KeyCode.F;

	private GameObject objectiveTextPrefab;

	// To initialize in the inspector.
	public Vector3 inDirection;
	public Vector3 outDirection;
	public float shipSpeed;

	public Motherland motherland;
	public DockingProbe dockingProbe;
	public GameObject invisibleGate;

	public int dockingStationId;
	public Vector3 startPos;
	public Vector3 exitPos;


	// Ship Info
	[HideInInspector] public string shipName;
	[HideInInspector] private ResourceType resourceType;
	[HideInInspector] private float resourceQuantity;
	[HideInInspector] public bool docked;



	// Ship Status String
	[HideInInspector] public string awaitingDockingStatusMsg 				= "Awaiting docking.";
	[HideInInspector] public string dockedAndUnloadingStatusMsg 			= "Docked. Unloading...";
	[HideInInspector] public string dockedAndFinishedUnloadingStatusMsg 	= "Docked. Finished unloading.";
	[HideInInspector] public string undockingAndReturningStatusMsg 			= "Undocked. Returning to "; // Expected to be followed by shipName

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

	//////////////////////
	// Collision Impact //
	//////////////////////
	void OnCollisionEnter (Collision other) {
		currentState.OnCollisionEnter (other);
	}

	public void DamageCargo (float magnitude) {
		// TODO Adjust the damage.
		SetShipResourceQuantity (GetShipResourceQuantity () - magnitude);
	}
	//////////////////////

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
	public string GetShipName () {
		return shipName;
	}

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
		UIManager.manager.UpdateStationInfoQuantity (dockingStationId, this);
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
			// Unload only when motherland has space.
			if (motherland.AddResources (resourceType, unloadRate)) {
				SetShipResourceQuantity (quantity - unloadRate);
				StartCoroutine (UnloadEverySecond ());
			}

		} else if (quantity <= 0) {
			Debug.Log (shipName + " finished unloading.");
			UIManager.manager.SetupStationStatus (dockingStationId, dockedAndFinishedUnloadingStatusMsg);
		} else {
			Debug.Log (shipName + " undocked while unloading. Remaining resource amount: " + resourceQuantity);
		}
	}

}
