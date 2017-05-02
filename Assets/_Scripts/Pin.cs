using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = 5.0f;

	public bool IsStanding() {

		Vector3 rotationInEuler = transform.eulerAngles;

		float tiltInx = Mathf.Abs( rotationInEuler.x );
		float tiltInz = Mathf.Abs( rotationInEuler.z );

		if (tiltInx <= (standingThreshold) || tiltInx >= (360 - standingThreshold)) {
			if (tiltInz <= (standingThreshold) || tiltInz >= (360 - standingThreshold)) {
				return true;
			}
		}

		return false;
	}
}
