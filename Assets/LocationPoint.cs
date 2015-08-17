using UnityEngine;
using System.Collections;

public class LocationPoint : MonoBehaviour {

	private NavMeshAgent agent;
	private Vector3 selectedPoint;
	private Vector3 lastPosition;

	//declare external script
	public FootstepScript steps;
	//a boolean to handle the stop footstep audio call
	private bool isStopped = true;

	void Start() {
		this.agent = GetComponent<NavMeshAgent> ();

		//assign script to variable
		steps = GetComponent<FootstepScript>();
	}

	//check update to see if still moving, if not moving; stop footstep audio
	//		movement is quadruple checked because sometimes it thinks it has 
	//		stopped when the pathfinder moves around an obstacle
	void Update(){
		//only check for 'stop' event while moving

			if (!this.agent.pathPending) {
				if(this.agent.remainingDistance <= this.agent.stoppingDistance){
					if(!this.agent.hasPath || this.agent.velocity.sqrMagnitude == 0f){
						if(!isStopped){
							steps.stopFootsteps();
							
							Debug.Log (this.agent.pathPending.ToString() + " " + this.agent.remainingDistance.ToString() + " " + this.agent.stoppingDistance.ToString() + " " + this.agent.hasPath.ToString() + " " + this.agent.velocity.sqrMagnitude.ToString() );

							isStopped = true;
							Debug.Log(this.transform.position);
							
						}
					}
				}
			}
		/*
		if(!isStopped){
			if(this.transform.position == lastPosition){
				Debug.Log ("WE STOPPED IT SO WE DID");
				steps.stopFootsteps();
				isStopped = true;
			}
		}
		*/
		lastPosition = this.transform.position;


		
	}

	public void MoveToLocationPoint(Component locationMarker){
		selectedPoint = locationMarker.transform.position;
		this.agent.destination = selectedPoint;
		Debug.Log(this.transform.position);
		steps.beginFootsteps();
		isStopped = false;

	}
}
