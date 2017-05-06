using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public Text standingDisplay;
	public GameObject pinSet;

	private Ball ball;
	private float lastChangedTime;
	private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballEnteredBox) {
			UpdateStandingCountAndSettle ();
		}
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
		ball.Reset ();
		lastStandingCount = -1; // Indicates opins have settled
		ballEnteredBox = false;
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
		Debug.Log("Raising Pins");

		//Pin[] pins = GameObject.FindObjectsOfType<Pin> ();

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin> ()) {
			if (pin.IsStanding ()) {
				pin.Raise ();
			}
		}
	}

	public void LowerPins () {
		//raise standing pins only by distance To Raise;
		Debug.Log("Lowering Pins");

		//Pin[] pins = GameObject.FindObjectsOfType<Pin> ();

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin> ()) {
			if (pin.IsStanding ()) {
				pin.Lower ();
			}
		}
	}

	public void RenewPins () {
		Debug.Log("Renewing Pins");

		GameObject newPins = Instantiate (pinSet);
		newPins.transform.position += new Vector3 (0, (40f + 5f), 0);

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin> ()) {
			pin.GetComponent<Rigidbody> ().isKinematic = true;
			pin.GetComponent<Rigidbody> ().useGravity = false;
		}
	}

	void OnTriggerEnter(Collider collider) {
		GameObject thingHit = collider.gameObject;

		// Ball enters play box.
		if (thingHit.GetComponentInChildren<Ball> ()) {
			standingDisplay.color = Color.red;
			ballEnteredBox = true;
		}
	}
}
