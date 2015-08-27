using UnityEngine;
using System.Collections;

public class Acquirable : MonoBehaviour {

	//private bool acquired = false;
	GameObject doorTrigger;

	// method to acquire the object
	public void Acquire (){
		//acquired = true;
		//find the object which has the position for the acquired object and will be the parent of the object to acquire
		GameObject acquiredObject = GameObject.Find("AcquiredObjectPosition");
		transform.position = acquiredObject.transform.position;
		transform.parent = acquiredObject.transform;
		this.GetComponent<AudioSource>().Play ();
		if (doorTrigger=GameObject.Find ("OpenDoorTrigger")){
			OpenDoorScript ods = doorTrigger.GetComponent<OpenDoorScript>();
			if(!ods.doorTriggerActive){
				ods.doorTriggerActive=true;
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
}
