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

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager>();
		//Action currentAction = new Action();
	}
	
	// Update is called once per frame
	void Update () {

		if (ballOutOfPlay){
		CheckStanding();
		amountOfPinsText.color = Color.magenta;
		amountOfPinsText.text = CountStandingPins().ToString();
		}
	}

	public void Reset(){
		lastSettled = 10;
	}

	void CheckStanding () {
	int currentStanding = CountStandingPins();

	if (currentStanding != lastStandingCount) {
		lastChangeTime = Time.time;
		lastStandingCount = currentStanding;
		return;
	}

	float settleTime = 3f;
	if (Time.time - lastChangeTime > settleTime){
		PinsHaveSettled();
	}
}

void PinsHaveSettled () {

	int standing = CountStandingPins();
	int pinsFallen = lastSettled - standing;
	lastSettled = standing;

	gameManager.Bowl(pinsFallen);

	lastStandingCount = -1;
	ballOutOfPlay = false;
	amountOfPinsText.text = CountStandingPins().ToString();
	amountOfPinsText.color = Color.green;
}

int CountStandingPins () {
	int standingPinsNumber = 0;

		foreach (Pin pinObject in GameObject.FindObjectsOfType<Pin>()) {

			if(pinObject.IsStanding()){
				standingPinsNumber ++;
			}
		}
		return standingPinsNumber;
}

//void OnTriggerEnter (Collider coll){
//
//	if (coll.GetComponent<BallMovement>()){
//	amountOfPinsText.color = Color.red;
//	ballOutOfPlay = true;
//	}
//}
	void OnTriggerExit(Collider coll){
		if (coll.gameObject.name == "Ball"){
			ballOutOfPlay = true;
			}
		if (coll.gameObject.GetComponentInParent<Pin>()){
			Debug.Log("Pin left the collider");
		Destroy(coll.transform.parent.gameObject);
	}
	}


}
