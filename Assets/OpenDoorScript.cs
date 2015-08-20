using UnityEngine;
using System.Collections;

public class OpenDoorScript : MonoBehaviour {

	private DoorState doorState = DoorState.CLOSED;
	private Transform doorHingeTransform;

	private float closedRotationAngle = 0f;

	public bool clockWiseOpenDoor = true;

	private AudioSource doorOpenAudio;

	// Use this for initialization
	void Start () {
		Transform parentTransform = gameObject.transform.parent;
		doorHingeTransform = parentTransform.FindChild("Hinge");
		doorOpenAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//TODO Remove - for testing only
		//GameObject player = GameObject.Find("Player");
		//Vector3 currentPosition = player.transform.position;
		//player.transform.position = Vector3.MoveTowards(currentPosition, gameObject.transform.position, 0.05f);
		if (closedRotationAngle >= 70f || closedRotationAngle <= -70f) {
			doorState = DoorState.OPEN;
			Debug.Log("open");
		}

		if (doorState.Equals(DoorState.OPENING)){

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
		if (other.gameObject.name.Equals("Player")) {
			OpenDoor();
			//converting/casting component to an object of type Collider
			Collider doorCollider = (Collider) gameObject.GetComponent(typeof(Collider));
			doorCollider.enabled = false;
			GameObject actualDoor = transform.parent.gameObject;
			Transform particleSystemTransform = transform.parent.FindChild("Particle System");
			if (particleSystemTransform !=null) {
				ParticleSystem particleSystem = (ParticleSystem) particleSystemTransform.GetComponent(typeof(ParticleSystem));
				particleSystem.enableEmission = false;
			}
		}
	}

	void OpenDoor(){
		Debug.Log("Opening");
		doorOpenAudio.Play();
		doorState = DoorState.OPENING;
	}
}

public enum DoorState {
	OPEN, CLOSED, OPENING
}
