using UnityEngine;
using System.Collections;

public class LocationPoint : MonoBehaviour {

	private NavMeshAgent agent;
	private Vector3 selectedPoint;

	void Start() {
		this.agent = GetComponent<NavMeshAgent> ();
	}

	public void MoveToLocationPoint(Component locationMarker){
		selectedPoint = locationMarker.transform.position;
		this.agent.destination = selectedPoint;
	}
}
