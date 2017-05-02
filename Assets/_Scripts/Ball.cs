﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public Vector3 launchVelocity;

	public  bool inPlay = false;

	private Rigidbody rigidBody;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();

		rigidBody.useGravity = false;
		//Launch (launchVelocity);
	}

	public void Launch (Vector3 velocity) {
		inPlay = true;
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;
		audioSource.Play ();
	}
}
