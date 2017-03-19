using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

public float standingThreshold = 3f;
public float distanceToRaise = 40f;
private Rigidbody rigidBody;

void Start()
    {
	rigidBody = GetComponent<Rigidbody>();
    } 
 
//check if pins are standing (check threshold to check wobbling pins)    
public bool IsStanding()
{
    float tiltX = (transform.eulerAngles.x < 180f) ? transform.eulerAngles.x : 360 - transform.eulerAngles.x;
    float tiltZ = (transform.eulerAngles.z < 180f) ? transform.eulerAngles.z : 360 - transform.eulerAngles.z;

    if (tiltX > standingThreshold || tiltZ > standingThreshold)
    {
        return false;
    }    
    return true;
}

//raising pins and setting them to no movement
public void RaiseIfStanding()
    {
	if(IsStanding())
        {
		rigidBody.useGravity = false;
		transform.Translate(new Vector3 (0f, distanceToRaise, 0f), Space.World);
		rigidBody.velocity = new Vector3 (0f, 0f, 0f);
		rigidBody.angularVelocity = new Vector3 (0f, 0f, 0f);
		rigidBody.transform.rotation = Quaternion.Euler(0,0,0);
		}
}

    //lowering pins
public void LowerIfStanding()
    {
	if(IsStanding())
        {
		transform.Translate(new Vector3 (0f, -distanceToRaise, 0f), Space.World);
		rigidBody.useGravity = true;
		}
    }
}


