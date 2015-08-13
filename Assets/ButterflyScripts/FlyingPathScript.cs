using UnityEngine;
using System.Collections;

public class FlyingPathScript : MonoBehaviour {



	//method that gets the point with the lowest order that has not been reached
	public GameObject getNextPathPoint (){
		//declares a new variable called nextPathPointScript of type PathPointScript
		PathPointScript nextPathPointScript = null; 

		// iterate through all child objects of our flying path
		foreach (Transform child in transform)
		{
			if (child.gameObject.name.Equals("PathPoint")) {
				//from the child trasform get the gameObject and from the gameObject get the PathPointScript component
				PathPointScript pathPointScript = child.gameObject.GetComponent<PathPointScript>();

				//check if the pathPoint object has been reached
				if ( !pathPointScript.hasBeenReached() ){
					//check if the nextPathPoint has not been set or order of the pathPoint object is less than nextPathPoint's order
					if (nextPathPointScript == null || pathPointScript.getOrder() < nextPathPointScript.getOrder()) {
						//if so, pathPoint becomes the next pathPoint
						nextPathPointScript = pathPointScript;
					}
				}
			}
		}

		//Check if nextPathPoint isn't null (i.e. there is a remaining path point to fly to)
		if(nextPathPointScript != null) {
			// get and return the gameObject from the PathPointScript component
			return nextPathPointScript.gameObject;
		}
		return null;
	}
}
