using UnityEngine;
using System.Collections;

public class dialogueTriggerF : MonoBehaviour {

	public GameObject theEngineChapel;
	public dialogueEngineChapel externalScriptChapel;
	private bool isColliding;
	private bool sceneStarted;
	private bool activeTrigger;

	public GameObject exitDoorObj;
	public OpenDoorScript exitDoorScript;
	
	// Use this for initialization
	void Start () {
		theEngineChapel = GameObject.Find ("Dialogue Engine Chapel Object");
		externalScriptChapel = theEngineChapel.GetComponent<dialogueEngineChapel>();
		isColliding = false;
		sceneStarted = false;
		activeTrigger = false;
	
		exitDoorScript = GameObject.Find ("OpenDoorTrigger").GetComponent<OpenDoorScript>();

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
			//this trigger is for CHAPEL SCENE PART II
			externalScriptChapel.triggerClipRoutine(5);
			exitDoorScript.activateDoorTrigger();
		}        
	}
	
	public void externalCallbackActivate(){
		activeTrigger = true;
	}
	
	public void externalCallbackDeactivate(){
		activeTrigger = false;
		exitDoorScript.activateDoorTrigger();
	}
}
