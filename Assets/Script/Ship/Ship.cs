using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	// Ship States
	IShipState currentState;
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


	public string name;
	public Vector3 startPos;
	public Vector3 exitPos;
	[HideInInspector] public bool docked;

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
		enterScreenState = new EnterScreenState (this);
		exitScreenState = new ExitScreenState (this);
		undockedState = new UndockedState (this);
		dockedState = new DockedState (this);

		Debug.Log ("Ship's initial state: EnterScreen");
		currentState = enterScreenState;
		currentState.EnterState ();
	}

	public void StateTransitionTo (IShipState newState) {
		currentState.ExitState ();
		currentState = newState;
		currentState.EnterState ();
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

}
