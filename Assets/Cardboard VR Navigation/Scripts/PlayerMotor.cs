﻿/* © 2015 Studio Pepwuper http://www.pepwuper.com */

using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {

	public GameObject Cursor; // Google Cardboard SDK: Cursor / GazePointer from CardboardMain Prefab
	private Vector3 goal;
	private NavMeshAgent agent;

	//declare external script
	//public FootstepScript steps;
	
	void Start() {
		Debug.Log ("MOTOR INIT");
		this.agent = GetComponent<NavMeshAgent>();
		this.goal = new Vector3(0f, 0f, 0f);
		//assign script to variable
		//steps = GetComponent<FootstepScript>();
		//Debug.Log (steps);
	}

	/*
	void Update(){
		if (!this.agent.pathPending) {
			if(this.agent.remainingDistance <= this.agent.stoppingDistance){
				if(!this.agent.hasPath || this.agent.velocity.sqrMagnitude == 0f){
					steps.stopFootsteps();
				}
			}
		}
	}
	*/

 				
	
	
	//Set navigation destination to the position of the cursor
	//Ex. Call this from an event trigger on the floor object
	public void SetDestinationToCursor() {
		this.goal = Cursor.transform.position;
		MoveToDestination();
	}
	
	void MoveToDestination(){
		this.agent.destination = goal;
		//Debug.Log("BEGIN STEPS");
		//steps.beginFootsteps();
	}
}