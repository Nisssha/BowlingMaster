using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public Vector3 launchSpeed;
    private Rigidbody ball;
    private AudioSource audioPlay;
    private float xposition;
	private Vector3 startingPosition;
	public bool inPlay = false;

	void Start ()
    {
        ball = GetComponent<Rigidbody>();
        ball.useGravity = false;
        audioPlay = FindObjectOfType<AudioSource>();
        startingPosition = transform.position;
	}

    // Launching the ball
    public void Launch(Vector3 launchSpeed)
    {
    if (!inPlay)
        {
    	inPlay = true;
		ball.useGravity = true;
        ball.velocity = launchSpeed;
        audioPlay.Play();
        }
    }

    //Move the ball before game has started to the right
    public void TweakPositionRight ()
    {
    	if (ball.transform.position.z == 10)
        {
    		xposition = ball.transform.position.x + 1;
    		ball.transform.position = new Vector3 (xposition, ball.transform.position.y, ball.transform.position.z);
    	}
    }

    //Move the ball before game has started to the left
    public void TweakPositionLeft ()
    {
		if (ball.transform.position.z == 10)
        {
    		xposition = ball.transform.position.x - 1;
    		ball.transform.position = new Vector3 (xposition, ball.transform.position.y, ball.transform.position.z);
    	}
    }

    //moving ball back to the start position and setting the movement to none
    public void Reset()
    {
    	inPlay = false;
    	transform.position = startingPosition;
    	ball.velocity = new Vector3 (0f, 0f, 0f);
    	ball.angularVelocity = new Vector3 (0f, 0f, 0f);
    	ball.rotation = (Quaternion.identity);
    }
}
