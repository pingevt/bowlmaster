using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = 5.0f;
	public float distanceToRaise = 40f;

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	public bool IsStanding() {

		Vector3 rotationInEuler = transform.eulerAngles;

		float tiltInx = Mathf.Abs( 270 - rotationInEuler.x );
		float tiltInz = Mathf.Abs( rotationInEuler.z );

		if (tiltInx <= (standingThreshold) || tiltInx >= (360 - standingThreshold)) {
			if (tiltInz <= (standingThreshold) || tiltInz >= (360 - standingThreshold)) {
				return true;
			}
		}

		return false;
	}

	public void Raise() {
		if (IsStanding ()) {
			rigidBody.isKinematic = true;
			transform.Translate (new Vector3 (0, 0, distanceToRaise));
			rigidBody.useGravity = false;
		}
	}

	public void Lower() {
		if (IsStanding ()) {
			rigidBody.isKinematic = true;
			transform.Translate (new Vector3 (0, 0, -distanceToRaise));
			rigidBody.useGravity = false;
		}
	}
}
