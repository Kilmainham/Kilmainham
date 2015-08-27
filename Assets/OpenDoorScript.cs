using UnityEngine;
using System.Collections;

public class OpenDoorScript : MonoBehaviour {
	public bool doorTriggerActive;
	public float openDegree = 90f;

	
	private DoorState doorState = DoorState.CLOSED;
	private Transform doorHingeTransform;
	
	private float closedRotationAngle = 0f;
	
	public bool clockWiseOpenDoor = true;
	
	private AudioSource doorOpenAudio;
	private AudioClip closedClip;
	
	// Use this for initialization
	void Start () {
		Transform parentTransform = gameObject.transform.parent;
		doorHingeTransform = parentTransform.FindChild("Hinge");
		doorOpenAudio = GetComponent<AudioSource>();
		closedClip = (AudioClip)Resources.Load("Sound/Objects/Locked Door");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (closedRotationAngle >= openDegree || closedRotationAngle <= -1*openDegree) {
			doorState = DoorState.OPEN;
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
		if (doorTriggerActive && other.gameObject.name.Equals("Player")) {
			OpenDoor();
			//converting/casting component to an object of type Collider
			Collider doorCollider = (Collider) gameObject.GetComponent(typeof(Collider));
			doorCollider.enabled = false;
		}
		if(!doorTriggerActive){


		}




	}
	
	public void OpenDoor(){
		if (doorTriggerActive){
			doorOpenAudio.Play();
			doorState = DoorState.OPENING;			

			Transform particleSystemTransform = transform.parent.FindChild("Particle System");
			if (particleSystemTransform !=null) {
				ParticleSystem particleSystem = (ParticleSystem) particleSystemTransform.GetComponent(typeof(ParticleSystem));
				particleSystem.enableEmission = false;
			}
		}
		if (!doorTriggerActive){
			doorOpenAudio.PlayOneShot(closedClip);
		}


	}

	public void activateDoorTrigger(){
		doorTriggerActive = true;
		
	}
}

public enum DoorState {
	OPEN, CLOSED, OPENING
}