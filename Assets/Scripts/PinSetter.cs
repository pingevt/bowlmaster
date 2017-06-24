using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public GameObject pinSet;


	private Animator animator;
	private PinCounter pinCounter;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		pinCounter = GameObject.FindObjectOfType<PinCounter> ();
	}
	
	// Update is called once per frame
	void Update () {

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

	public void PerformAction (ActionMaster.Action action) {
		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
		} else if (action == ActionMaster.Action.EndTurn || action == ActionMaster.Action.Reset) {
			pinCounter.Reset ();
			animator.SetTrigger ("resetTrigger");
		} else if (action == ActionMaster.Action.EndGame) {
			throw new UnityException ("Don't know how to handle end game yet");
		}
	}
}
