using UnityEngine;
using System;
using System.Collections;


public class transform : MonoBehaviour {
	//This script is for rescaling the gui gaze pointer reticle so it maintains its apparant size on screen while still appearing at different render depths.
	public Component player;

	private Vector3 playerlocation;
	private Vector3 reticlelocation;
	private float distancemagnitude;
	private float inversedist;
	private float x;
	private float y;
	private float z;
	public float magconst = 0.04f;
	

	// Update is called once per frame
	void Update () {


		playerlocation = player.transform.position;
		reticlelocation = this.transform.position;
		x = playerlocation.x-reticlelocation.x;
		y = playerlocation.y-reticlelocation.y;
		z = playerlocation.z-reticlelocation.z;

		distancemagnitude =  Mathf.Sqrt(x*x + y*y+ z*z);

		//Debug.Log("Magnitude = "+distancemagnitude);

		//Debug.Log (playerlocation);
		//Debug.Log(this.transform.position);
		transform.localScale = new Vector3(distancemagnitude*magconst, 0, distancemagnitude*magconst);

	}
}
