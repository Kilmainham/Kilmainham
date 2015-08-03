using UnityEngine;
using System.Collections;

public class FollowFlyingPath : MonoBehaviour {

	private const float speed = 0.05f;

	GameObject flyingPath;
	//getter to return game object
	public GameObject GetFlyingPath () {
		return flyingPath;
	}
	//setter to set game object
	public void SetFlyingPath (GameObject newFlyingPath) {
		//setting the flyingPath to newFlyingPath
		this.flyingPath=newFlyingPath;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame 
	void Update () {
	
	}
	// execute the method in fixed intervals (Unity setting), updates physical things, movements and such
	void FixedUpdate () {
		// find the game object flyingPath with the name "FlyingPath"
		//GameObject flyingPath = GameObject.Find("FlyingPath");

		//execute if flyingPath is not null
		if (flyingPath != null) {
		                       
			// get flying path script component from the flying path game object
			FlyingPathScript flyingPathScript = flyingPath.GetComponent<FlyingPathScript>();
			// calls the method on the flyingPathScript that returns the next path point
			GameObject nextPathPoint = flyingPathScript.getNextPathPoint();

			if (nextPathPoint != null) {
				// get the position of the next path point
				Vector3 nextPathPointPosition = nextPathPoint.transform.position;
				//find the game object butterfy 
				GameObject butterfly = GameObject.Find ("butterfly");
				// get the position of the butterfly
				Vector3 butterflyPosition = butterfly.transform.position;
				// move towards target from the current position butterfly position
				butterfly.transform.position = Vector3.MoveTowards(butterflyPosition, nextPathPointPosition, speed);
				// check if the butterfly reached the next path point position
				if (butterfly.transform.position.Equals(nextPathPointPosition)){
					// get pathPoint script component from the nextPathPoint game object
					PathPointScript pathPointScript = nextPathPoint.GetComponent<PathPointScript>();
					//sets the variable reached to true on the path point
					pathPointScript.setReached(true);
				}
			}
		}
	}

}
