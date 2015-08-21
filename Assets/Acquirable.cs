using UnityEngine;
using System.Collections;

public class Acquirable : MonoBehaviour {

	private bool acquired = false;
	GameObject doorTrigger;
	public void Acquire (){
		acquired = true;
		GameObject acquiredObject = GameObject.Find("AcquiredObjectPosition");
		transform.position = acquiredObject.transform.position;
		transform.parent = acquiredObject.transform;
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
	
	// Update is called once per frame
	/*void Update () {
		if (Input.GetMouseButtonDown(0)){
			Acquire();
			Debug.Log("Acquire CANDLE.");
		}
	
	}*/
}
