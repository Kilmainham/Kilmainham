using UnityEngine;
using System.Collections;

public class PathPointScript : MonoBehaviour {

	public int order;

	private bool reached = false;

	public int getOrder (){
		return order;
	}

	public void setReached(bool newReachedValue){
		reached = newReachedValue;
	}

	public bool hasBeenReached(){
		return reached;
	}
}
