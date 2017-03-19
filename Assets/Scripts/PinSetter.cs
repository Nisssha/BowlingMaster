using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PinSetter : MonoBehaviour {

public GameObject pinSet;

private Animator animator;
private PinCounter pinCounter;

void Start ()
    {
	animator = GameObject.FindObjectOfType<Animator>();
	pinCounter = GameObject.FindObjectOfType<PinCounter>();
    }

    //raise all the pins if they are standing
public void RaisePins()
    {
	foreach (Pin pinObject in GameObject.FindObjectsOfType<Pin>())
            {
				pinObject.RaiseIfStanding();
			}
    }

    //raise all the pins if they are standing
public void LowerPins()
    {
	foreach (Pin pinObject in GameObject.FindObjectsOfType<Pin>())
            {
				pinObject.LowerIfStanding();
			}
    }

    //create new set of pins
public void RenewPins ()
    {
	Instantiate(pinSet, new Vector3 (0f, 40f, 0f), Quaternion.identity);
    }

    //trigger apropriate actions
public void PerformAction (ActionMaster.Action action)
    {
	if (action == ActionMaster.Action.Tidy)
        {
		    animator.SetTrigger("tidyTrigger");
		}
        else if (action == ActionMaster.Action.Reset)
        {
		    pinCounter.Reset();
		    animator.SetTrigger("resetTrigger");
		}
        else if (action == ActionMaster.Action.EndTurn)
        {
		    pinCounter.Reset();
		    animator.SetTrigger("resetTrigger");
		}
        else if (action == ActionMaster.Action.EndGame)
        {
		    throw new UnityException ("End game triggered");
        }
    }
}
