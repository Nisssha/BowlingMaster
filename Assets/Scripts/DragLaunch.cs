using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallMovement))]
public class DragLaunch : MonoBehaviour {

	private BallMovement ball;
	private float dragTimeStart, dragTimeEnd, dragTime;
	private Vector3 dragStartPosition, dragEndPosition, dragLength, dragVelocity, dragLengthInZ;
	// Use this for initialization
	void Start () {
		ball = GetComponent<BallMovement>();
	}
	
	public void DragStart () {
		dragTimeStart = Time.time;
		dragStartPosition = Input.mousePosition;
		//capture time nd position of the drag start
	}

	public void DragStop () {
		dragTimeEnd = Time.time;
		dragTime = dragTimeEnd - dragTimeStart;
		dragEndPosition = Input.mousePosition;

		dragLength = dragEndPosition - dragStartPosition;

		float dragInZ = dragEndPosition.y;

		dragVelocity = new Vector3 (dragLength.x, 0f, dragInZ)/dragTime;

		ball.Launch(dragVelocity);
		}
}
