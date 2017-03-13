using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

private List <int> rolls = new List <int>();
private PinSetter pinSetter;
private BallMovement ball;
private ScoreDisplay scoreDisplay;

void Start(){
	pinSetter = GameObject.FindObjectOfType<PinSetter>();
	ball = GameObject.FindObjectOfType<BallMovement>();
	scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
}

public void Bowl (int pinFalls) {

try{
	rolls.Add(pinFalls);
	ball.Reset();

	pinSetter.PerformAction(ActionMaster.NextAction(rolls));
	}catch {
	Debug.LogWarning("Something went wrong in game manager bowl");
	}

try{
	scoreDisplay.FillRolls(rolls);
	scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
	}catch{
	Debug.LogWarning("Something is wrong with scoredisplay.fillrollcard");
	}
}

}
