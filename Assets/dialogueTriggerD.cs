using UnityEngine;
using System.Collections;

public class dialogueTriggerD : MonoBehaviour {

	public GameObject theEngineEastWing;
	public dialogueEngineEastWing externalScriptEastWing;
	private bool isColliding;
	private bool sceneStarted;
	private bool activeTrigger;
	
	// Use this for initialization
	void Start () {
		theEngineEastWing = GameObject.Find ("Dialogue Engine East Wing Object");
		externalScriptEastWing = theEngineEastWing.GetComponent<dialogueEngineEastWing>();
		isColliding = false;
		sceneStarted = false;
		activeTrigger = true;
		Debug.Log ("Awake Trigger");
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
			//this trigger is for EAST WING GUARDS
			externalScriptEastWing.triggerClipRoutine(3);
			Debug.Log ("TRIGGERED D");
		}        
	}
	
	public void externalCallbackActivate(){
		activeTrigger = true;
	}
	
	public void externalCallbackDeactivate(){
		activeTrigger = false;
	}

}
