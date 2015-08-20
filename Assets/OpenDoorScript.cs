﻿using UnityEngine;
using System.Collections;

public class OpenDoorScript : MonoBehaviour {

	private DoorState doorState;
	private Transform doorHingeTransform;

	private float closedRotationAngle = 0f;

	private AudioSource doorAudio;

	// Use this for initialization
	void Start () {
		doorState = DoorState.CLOSED;
		Transform parentTransform = gameObject.transform.parent;
		doorHingeTransform = parentTransform.FindChild("Hinge");
		doorAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//TODO Remove - for testing only
		//GameObject player = GameObject.Find("Player");
		//Vector3 currentPosition = player.transform.position;
		//player.transform.position = Vector3.MoveTowards(currentPosition, gameObject.transform.position, 0.05f);

		if (doorState.Equals(DoorState.OPENING)){
			Transform parentTransform = gameObject.transform.parent;
			parentTransform.RotateAround(doorHingeTransform.position, Vector3.up, 2f);
			closedRotationAngle = closedRotationAngle + 2f;
			if (closedRotationAngle >= 90f) {
				doorState = DoorState.OPEN;
				Debug.Log("open");
			}
		}
	}

	/*void OnTriggerStay(Collider other) {
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
	}*/

	public void OpenDoor(){
		if (doorState == DoorState.CLOSED){
			Debug.Log("Opening");
			doorAudio.Play();
			doorState = DoorState.OPENING;

		}
	}
}

public enum DoorState {
	OPEN, CLOSED, OPENING
}
