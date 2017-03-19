using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	private BallMovement ball;

	private Vector3 offset;
	private float offset_x, offset_y, offset_z;
	
    // Get the difference in position between the ball and the camera at the start 
	void Start ()
    {
		ball = GameObject.FindObjectOfType<BallMovement>();
		offset_x = ball.transform.position.x - transform.position.x;
		offset_y = ball.transform.position.y - transform.position.y;
		offset_z = ball.transform.position.z - transform.position.z;
		offset = new Vector3 (offset_x, offset_y, offset_z);
	}
	
	// Moving camera with the ball movement
	void Update () {

		if (transform.position.z <= (1829f - offset.z)) {
			transform.position = ball.transform.position - offset;
		}else if (!ball.inPlay) {
			transform.position = ball.transform.position - offset;
		}	
	}
}
