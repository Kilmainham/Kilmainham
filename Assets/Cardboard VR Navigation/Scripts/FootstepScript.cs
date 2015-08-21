using UnityEngine;
using System.Collections;

/*
 * 		-this script contains the functions for playing footsteps when the 
 * 			player moves
 * 		-the functions are triggered from the LocationPoint script
*/

public class FootstepScript : MonoBehaviour {

	private bool isLeftLeg;
	private float walkSpeed;
	private float legPan;
	public AudioClip[] concreteFootsteps;
	private AudioSource myAudio;
	private int randomClip;
	private int lastClip;
	public AudioLowPassFilter footFilter;
	private int filterCut;

	// Use this for initialization
	void Start () {
		//load the concrete footstep clips
		concreteFootsteps =  new AudioClip[]
		{	
			Resources.Load("Sound/footsteps/concrete/concrete1")   as AudioClip,
			Resources.Load("Sound/footsteps/concrete/concrete2")   as AudioClip,
			Resources.Load("Sound/footsteps/concrete/concrete3")   as AudioClip,
			Resources.Load("Sound/footsteps/concrete/concrete4")   as AudioClip

			
		};
		
		// initialise walk logic
		walkSpeed = 0.4f;
		legPan = 0.3f;
		myAudio = GetComponent<AudioSource>();
		myAudio.spatialBlend = 0f; //use 2D audio
		myAudio.reverbZoneMix = 0.3f; //use reverb zones
		myAudio.panStereo = -legPan; //left foot first (source panned 50% left)
		isLeftLeg = true;
		footFilter = GetComponent<AudioLowPassFilter>();
		filterCut = 4000;
		footFilter.cutoffFrequency = filterCut;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//called from PlayerMoter script when movement begins
	public void beginFootsteps(){
		InvokeRepeating("playFootsteps",walkSpeed,walkSpeed);
		Debug.Log ("CALLED");
	}

	//called from PlayerMoter script when movement ends 
	public void stopFootsteps(){
		CancelInvoke("playFootsteps");
		Debug.Log ("STOPPED");
	}

	void playFootsteps(){
		Debug.Log("PLAYED");
		// don't let clips overlap
		if(!myAudio.isPlaying)
		{
			// slightly vary filter cutoff for each step
			filterCut = Random.Range(2000, 4000);
			footFilter.cutoffFrequency = filterCut;

			// slightly vary pitch and volume of each sample
			myAudio.pitch = Random.Range(0.9f, 1.1f);
			myAudio.volume = Random.Range(0.6f, 1f);

			//pick random array index but don't repeat two in a row
			randomClip = Random.Range(0,3);
			while(randomClip == lastClip){
				randomClip = Random.Range(0,3);
			}
			//remember most recent clip for comparison
			lastClip = randomClip;

			//switch L to R
			if(isLeftLeg){
				//play a random clip from the array
				myAudio.PlayOneShot(concreteFootsteps[randomClip]);
				//switch legs (stereo pan settings)
				myAudio.panStereo = legPan;
				isLeftLeg = false;
				//return;
			}

			//switch R to L
			if(!isLeftLeg){
				//play a random clip from the array
				myAudio.PlayOneShot(concreteFootsteps[randomClip]);
				//switch legs (stereo pan settings)
				myAudio.panStereo = -legPan;
				isLeftLeg = true;
				//return;
			}
		}
		
	}
}


