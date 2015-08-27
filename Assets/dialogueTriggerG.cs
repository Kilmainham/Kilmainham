using UnityEngine;
using System.Collections;

public class dialogueTriggerG : MonoBehaviour {

	public GameObject theEngineYard;
	public dialogueEngineYard externalScriptYard;
	private bool isColliding;
	private bool sceneStarted;
	private bool activeTrigger;
	
	// Use this for initialization
	void Start () {
		theEngineYard = GameObject.Find ("Dialogue Engine Yard Object");
		externalScriptYard = theEngineYard.GetComponent<dialogueEngineYard>();
		isColliding = false;
		sceneStarted = false;
		activeTrigger = true;
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
			//this trigger is for Yard 
			externalScriptYard.triggerClipRoutine(6);
		}        
	}
	
	public void externalCallbackActivate(){
		activeTrigger = true;
	}
	
	public void externalCallbackDeactivate(){
		activeTrigger = false;
	}
}
