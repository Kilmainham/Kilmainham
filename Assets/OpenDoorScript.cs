using UnityEngine;
using System.Collections;

public class OpenDoorScript : MonoBehaviour {
	public bool doorTriggerActive;
	public float openDegree = 90f;
	private DoorState doorState = DoorState.CLOSED;
	private Transform doorHingeTransform;
	
	private float closedRotationAngle = 0f;
	
	public bool clockWiseOpenDoor = true;
	
	// Use this for initialization
	void Start () {
		//doorTriggerActive = false;
		Transform parentTransform = gameObject.transform.parent;
		doorHingeTransform = parentTransform.FindChild("Hinge");
	}
	
	// Update is called once per frame
	void Update () {
		//TODO Remove - for testing only
		//GameObject player = GameObject.Find("Player");
		//Vector3 currentPosition = player.transform.position;
		//player.transform.position = Vector3.MoveTowards(currentPosition, gameObject.transform.position, 0.05f);
		if (closedRotationAngle >= openDegree || closedRotationAngle <= -openDegree) {
			doorState = DoorState.OPEN;
			Debug.Log("open");
		}
		
		if (doorTriggerActive && doorState.Equals(DoorState.OPENING)){
			
			float openingAngle;
			
			if (clockWiseOpenDoor == true){
				openingAngle = 2f;
			}
			else {
				openingAngle = -2f;
			}
			
			Transform parentTransform = gameObject.transform.parent;
			parentTransform.RotateAround(doorHingeTransform.position, Vector3.up, openingAngle);
			closedRotationAngle = closedRotationAngle + openingAngle;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		//if this is true, the player entered the sphere and the door is opened
		if (doorTriggerActive && other.gameObject.name.Equals("Player")) {
			//Debug.Log ("colision");
			OpenDoor();
			//converting/casting component to an object of type Collider
			Collider doorCollider = (Collider) gameObject.GetComponent(typeof(Collider));
			doorCollider.enabled = false;
		}
	}
	
	void OpenDoor(){
		Debug.Log("Opening");
		doorState = DoorState.OPENING;
	}
	public void activateDoorTrigger(){
		doorTriggerActive = true;
		
	}
}

public enum DoorState {
	OPEN, CLOSED, OPENING
}	