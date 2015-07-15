using UnityEngine;
using System.Collections;

public class OpenDoorScript : MonoBehaviour {

	private DoorState doorState = DoorState.CLOSED;
	private Transform doorHingeTransform;

	private float closedRotationAngle = 0f;

	// Use this for initialization
	void Start () {
		Transform parentTransform = gameObject.transform.parent;
		doorHingeTransform = parentTransform.FindChild("Hinge");
	}
	
	// Update is called once per frame
	void Update () {
		//TODO Remove - for testing only
		GameObject player = GameObject.Find("Player");
		Vector3 currentPosition = player.transform.position;
		player.transform.position = Vector3.MoveTowards(currentPosition, gameObject.transform.position, 0.05f);

		if (doorState.Equals(DoorState.OPENING)){
			Transform parentTransform = gameObject.transform.parent;
			parentTransform.RotateAround(doorHingeTransform.position, Vector3.up, 2f);
			closedRotationAngle = closedRotationAngle + 2f;
		}
	}

	void OnTriggerStay(Collider other) {
		//if this is true, the player entered the sphere and the door is opened
		if (other.gameObject.name.Equals("Player")) {
			if (closedRotationAngle >= 90f) {
				doorState = DoorState.OPEN;
				Debug.Log("open");
			}
			else {
				OpenDoor();
			}
		}
	}

	void OpenDoor(){
		Debug.Log("Opening");
		doorState = DoorState.OPENING;
	}
}

public enum DoorState {
	OPEN, CLOSED, OPENING
}
