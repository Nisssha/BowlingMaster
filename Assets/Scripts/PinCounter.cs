using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinCounter : MonoBehaviour {
	
	public bool ballOutOfPlay = false;
	private Animator animator;
	private int lastStandingCount = -1;
	private float lastChangeTime;
	private int lastSettled = 10;
	public Text amountOfPinsText;
	private GameManager gameManager;

	void Start ()
    {
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}

    //count standing pins, display the amount
void Update ()
    {
		if (ballOutOfPlay)
        {
		CheckStanding();
		amountOfPinsText.color = Color.magenta;
		amountOfPinsText.text = CountStandingPins().ToString();
		}
	}

    //reset the number of standing 
public void Reset()
    {
		lastSettled = 10;
	}

    //check how many pins are standing, if number have change since last check: set the time of change and number of pins standing
    //after 3 seconds call PinsHaveSettled()
void CheckStanding ()
    {
	    int currentStanding = CountStandingPins();

	    if (currentStanding != lastStandingCount)
        {
		    lastChangeTime = Time.time;
		    lastStandingCount = currentStanding;
		    return;
	    }

	    float settleTime = 3f;
	    if (Time.time - lastChangeTime > settleTime)
        {
		    PinsHaveSettled();
	    }
}

    //check how many pins are standing and update the amount
    //call funtion Bowl with amount of pins fallen and display number of standing pins
void PinsHaveSettled ()
    {
	    int standing = CountStandingPins();
	    int pinsFallen = lastSettled - standing;
	    lastSettled = standing;

	    gameManager.Bowl(pinsFallen);

	    lastStandingCount = -1;
	    ballOutOfPlay = false;
	    amountOfPinsText.text = CountStandingPins().ToString();
	    amountOfPinsText.color = Color.green;
    }

    //count standing pins through pin function IsStanding and return number of standing pins
int CountStandingPins ()
    {
	int standingPinsNumber = 0;

		foreach (Pin pinObject in GameObject.FindObjectsOfType<Pin>())
        {
			if(pinObject.IsStanding())
            {
				standingPinsNumber ++;
			}
		}
		return standingPinsNumber;
    }

    //handling events when object leaves the box collider on the end
void OnTriggerExit(Collider coll)
    {
        //the object is Ball
		if (coll.gameObject.name == "Ball")
        {
			ballOutOfPlay = true;
		}
        //the object is a pin - destroy it
		if (coll.gameObject.GetComponentInParent<Pin>())
        {
		    Destroy(coll.transform.parent.gameObject);
	    }
	}
}
