using UnityEngine;
using System.Collections;

public class dialogueTriggerC : MonoBehaviour {

	public GameObject theEngineCorridor;
	public dialogueEngineCorridor externalScriptCorridor;
	private bool isColliding;
	private bool sceneStarted;
	private bool activeTrigger;
	
	// Use this for initialization
	void Start () {
		theEngineCorridor = GameObject.Find ("Dialogue Engine Corridor Object");
		externalScriptCorridor = theEngineCorridor.GetComponent<dialogueEngineCorridor>();
		isColliding = false;
		sceneStarted = false;
		activeTrigger = false;
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
			//this trigger is for VAGRANT and THIEF
			externalScriptCorridor.triggerClipRoutine(2);
			Debug.Log ("TRIGGERED C");
		}        
	}
	
	public void externalCallbackActivate(){
		activeTrigger = true;
	}
	
	public void externalCallbackDeactivate(){
		activeTrigger = false;
	}

}
