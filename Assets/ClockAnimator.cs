using UnityEngine;
using System;

public class ClockAnimator : MonoBehaviour {
	
	//set constant floating point for rotating the arrows hour in 12 and minutes - in 60 intervals
	private const float
		hoursToDegrees = 360f / 12f,
		minutesToDegrees = 360f/ 60f;

	//transform hours and minutes variable
	public Transform hours, minutes;

	public DateTime time;

	void Start (){
		//store temporary variable time in the DateTime Now property
		time = DateTime.Now;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)){
			ReverseOneHour();
			Debug.Log("Pressed left click.");
		}
		time = time.AddSeconds (Time.deltaTime);
		//change local rotation of the arrows around the Z axis
		hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
		minutes.localRotation = Quaternion.Euler(0f, 0f, time.Second * -minutesToDegrees);
	}

	//reversing time
	public void ReverseOneHour(){

		time = time.AddHours(-1);
	}

	
}


