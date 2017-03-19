using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallMovement))]
public class DragLaunch : MonoBehaviour {

	private BallMovement ball;
	private float dragTimeStart, dragTimeEnd, dragTime;
	private Vector3 dragStartPosition, dragEndPosition, dragLength, dragVelocity, dragLengthInZ;
	
	void Start ()
    {
		ball = GetComponent<BallMovement>();
	}
	
    //capture time and position of the beggining of the drag
	public void DragStart ()
    {
		dragTimeStart = Time.time;
		dragStartPosition = Input.mousePosition;
	}

    //capture time and position of the end of the drag
    //based on beginning and end of the drag calculate the velocity of the drag and call launching of the ball
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
