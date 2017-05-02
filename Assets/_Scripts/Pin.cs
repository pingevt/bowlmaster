using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public bool IsStanding() {

		Vector3 rotationInEuler = transform.eulerAngles;

		float tiltInx = Mathf.Abs( rotationInEuler.x );
		float tiltInz = Mathf.Abs( rotationInEuler.z );

		if (rotationInEuler.x <= (standingThreshold) || rotationInEuler.x >= (360 - standingThreshold)) {
			if (rotationInEuler.z <= (standingThreshold) || rotationInEuler.z >= (360 - standingThreshold)) {
				return true;
			}
		}

		return false;
	}
}
