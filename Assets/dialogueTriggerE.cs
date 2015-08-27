using UnityEngine;
using System.Collections;

public class dialogueTriggerE : MonoBehaviour {

	public GameObject theEngineChapel;
	public dialogueEngineChapel externalScriptChapel;
	private bool isColliding;
	private bool sceneStarted;
	private bool activeTrigger;

	//declare script for clock challenge
	public GameObject clockObj;
	public ClockAnimator clockScript;
	
	// Use this for initialization
	void Start () {
		theEngineChapel = GameObject.Find ("Dialogue Engine Chapel Object");
		externalScriptChapel = theEngineChapel.GetComponent<dialogueEngineChapel>();
		isColliding = false;
		sceneStarted = false;
		activeTrigger = true;

		clockObj = GameObject.Find ("Clock");
		clockScript = clockObj.GetComponent<ClockAnimator>();
	}
	
	// Update is called once per frame
	void Update () {
		isColliding = false;
	}


	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name.Equals("Player") && sceneStarted == false && activeTrigger == true){
			if(isColliding) return;
			isColliding = true;
			sceneStarted = true;
			//this trigger is for CHAPEL SCENE
			externalScriptChapel.triggerClipRoutine(4);
		}        
	}
	
	public void externalCallbackActivate(){
		activeTrigger = true;
	}
	
	public void externalCallbackDeactivate(){
		activeTrigger = false;

	}

	public void externalChallengeActivate(){
		clockScript.activateChallenge();

	}
}
