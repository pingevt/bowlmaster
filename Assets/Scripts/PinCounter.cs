using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	public Text standingDisplay;

	private GameManager gameManager;
	private bool ballOutOfPlay = false;
	private int lastStandingCount = -1;
	private float lastChangedTime;
	private int lastSettledCount = 10;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballOutOfPlay) {
			UpdateStandingCountAndSettle ();
			standingDisplay.color = Color.red;
		}
	}

	public void Reset () {
		lastSettledCount = 10;
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

		gameManager.Bowl (pinFall);

		lastStandingCount = -1; // Indicates pins have settled
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

	void OnTriggerExit (Collider collider) {
		if (collider.gameObject.name == "Ball") {
			ballOutOfPlay = true;
		}
	}
}
