using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball>();
	}

	public void MoveStart (float amount) {
		if (!ball.inPlay) {
			ball.transform.Translate (new Vector3 (amount, 0f, 0f));
		}
	}

	public void DragStart() {
		if (!ball.inPlay) {
			// Capture time & Position of drag start
			dragStart = Input.mousePosition;
			startTime = Time.time;
		}
	}

	public void DragEnd() {
		if (!ball.inPlay) {
			// Launch the ball
			dragEnd = Input.mousePosition;
			endTime = Time.time;

			float dragDuration = endTime - startTime;

			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

			ball.Launch (new Vector3 (launchSpeedX, 0, launchSpeedZ) * 2);
		}
	}


	public void LaunchStriaght() { 
		ball.Launch(new Vector3 (0, 0, 600));
	}
	public void LaunchLeft() { 
		ball.Launch(new Vector3 (-10, 0, 600));
		//Launch(new Vector3 (-20, 0, 600));
	}
	public void LaunchRight() { 
		ball.Launch(new Vector3 (10, 0, 600));
		//Launch(new Vector3 (20, 0, 600));
	}
} 
