using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PinSetter : MonoBehaviour {

public GameObject pinSet;

private Animator animator;
//private ActionMaster actionMaster;
private PinCounter pinCounter;

void Start () {
	//actionMaster = ScriptableObject.CreateInstance<ActionMaster>();
	//ActionMaster actionMaster = new ActionMaster();
	animator = GameObject.FindObjectOfType<Animator>();
	pinCounter = GameObject.FindObjectOfType<PinCounter>();
}

void Update () {
		
}

public void RaisePins() {
	foreach (Pin pinObject in GameObject.FindObjectsOfType<Pin>()) {
				pinObject.RaiseIfStanding();
			}
}
public void LowerPins() {

	foreach (Pin pinObject in GameObject.FindObjectsOfType<Pin>()) {
				pinObject.LowerIfStanding();
			}
}
public void RenewPins () {
	Instantiate(pinSet, new Vector3 (0f, 40f, 0f), Quaternion.identity);
}

public void PerformAction (ActionMaster.Action action) {

		Debug.Log(action);
	if (action == ActionMaster.Action.Tidy){
		animator.SetTrigger("tidyTrigger");
		}else if (action == ActionMaster.Action.Reset){
		pinCounter.Reset();
		animator.SetTrigger("resetTrigger");
		}else if (action == ActionMaster.Action.EndTurn){
		pinCounter.Reset();
		animator.SetTrigger("resetTrigger");
		}else if (action == ActionMaster.Action.EndGame){
		throw new UnityException ("End game triggered, don't know how to live my life, sent help plox");}
}
}
