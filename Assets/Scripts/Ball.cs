using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public Vector3 launchVelocity;
	public  bool inPlay = false;

	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 ballStartPos;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
		rigidBody.useGravity = false;
		ballStartPos = transform.position;
	}

	public void Launch (Vector3 velocity) {
		inPlay = true;
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;
		audioSource.Play ();
	}

	public void Reset() {
		inPlay = false;
		rigidBody.transform.position = ballStartPos;
		rigidBody.useGravity = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
	}

	public void LaunchStriaght() { 
		Launch(new Vector3 (0, 0, 600));
	}
	public void LaunchLeft() { 
		Launch(new Vector3 (-10, 0, 600));
		//Launch(new Vector3 (-20, 0, 600));
	}
	public void LaunchRight() { 
		Launch(new Vector3 (10, 0, 600));
		//Launch(new Vector3 (20, 0, 600));
	}
}
