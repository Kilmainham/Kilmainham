using UnityEngine;
using System;

public class ClockAnimator : MonoBehaviour {

	bool reversing = false;
	//target time each time I reverse
	DateTime targetTime;
	//should be equal to the length of the sound clip
	double totalReversalTime = 1.5;
	double totalTimeToBeReversed = 3600;
	int maximumReversal = 7;
	int numberOfReversals = 0;
	
	//set constant floating point for rotating the arrows hour in 12 and minutes - in 60 intervals
	private const float
		hoursToDegrees = 360f / 12f,
		minutesToDegrees = 360f/ 60f;

	//transform hours and minutes variable
	public Transform hours, minutes;
	//current clock time
	public DateTime time;


	void Start (){
		//store temporary variable time in the DateTime Now property
		time = DateTime.Now;
	}
	// method Update refreshes every frame
	void Update () {
		/*if (Input.GetMouseButtonDown(0) && reversing == false){
			StartReversal();
			Debug.Log("Pressed left click.");

		}*/
		//if reversing is true
		if (reversing){
			//call method reversing
			ProcessReversal();
		}
		time = time.AddSeconds (Time.deltaTime);
		//change local rotation of the arrows around the Z axis
		hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
		minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
	}

	//reversing time
	public void StartReversal(){
		
		if (numberOfReversals < maximumReversal && reversing == false){
			targetTime = time.AddSeconds(-totalTimeToBeReversed);
			reversing = true;
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
			numberOfReversals++;
		}

	}
	//reversing method
	public void ProcessReversal () {

		if (time.CompareTo(targetTime) > 0) {
			//amount to be adjusted
			time = time.AddSeconds((Time.deltaTime/totalReversalTime)*-totalTimeToBeReversed);

		}
		else {
			//stop reversing if time is reversed back one hour
			reversing = false;
		}
	}
	
}


