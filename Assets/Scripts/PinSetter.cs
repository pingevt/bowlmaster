using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text standingDisplay;
	public GameObject pinSet;

	private bool ballOutOfPlay = false;
	private int lastStandingCount = -1;
	private float lastChangedTime;
	private int lastSettledCount = 10;

	private ActionMaster actionMaster = new ActionMaster ();

	private Ball ball;
	private Animator animator;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballOutOfPlay) {
			UpdateStandingCountAndSettle ();
			standingDisplay.color = Color.red;
		}
	}

	public void SetBallOutOfPlay () {
		ballOutOfPlay = true;
	}

	void UpdateStandingCountAndSettle() {
		int currentStanding = CountStanding();

		if ( currentStanding != lastStandingCount) {
			lastChangedTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		// Call PinsHaveSettled() when they have.
		float settleTime = 3f;
		if ((Time.time - lastChangedTime) > settleTime) {
			PinsHaveSettled();
		}
	}

	void PinsHaveSettled() {
		int pinFall = lastSettledCount - CountStanding ();
		lastSettledCount = CountStanding ();

		ActionMaster.Action action = actionMaster.Bowl (pinFall);
		Debug.Log ("pinFall: " + pinFall + " Action: " + action);

		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
		} else if (action == ActionMaster.Action.EndTurn || action == ActionMaster.Action.Reset) {
			lastSettledCount = 10;
			animator.SetTrigger ("resetTrigger");
		} else if (action == ActionMaster.Action.EndGame) {
			throw new UnityException ("Don't know how to handle end game yet");
		}

		ball.Reset ();
		lastStandingCount = -1; // Indicates opins have settled
		ballOutOfPlay = false;
		standingDisplay.color = Color.green;
	}

	int CountStanding() {
		int standing = 0;

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin> ()) {
			if (pin.IsStanding ()) {
				standing++;
			}
		}
		 
		return standing;
	}

	public void RaisePins () {
		//raise standing pins only by distance To Raise;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin> ()) {
			pin.Raise ();
		}
	}

	public void LowerPins () {
		//raise standing pins only by distance To Raise;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin> ()) {
			pin.Lower ();
		}
	}

	public void RenewPins () {

		GameObject newPins = Instantiate (pinSet);
		newPins.transform.position += new Vector3 (0, (40f + 5f), 0);

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin> ()) {
			pin.GetComponent<Rigidbody> ().isKinematic = true;
			pin.GetComponent<Rigidbody> ().useGravity = false;
		}
	}
}
