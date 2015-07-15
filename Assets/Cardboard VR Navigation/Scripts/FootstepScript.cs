using UnityEngine;
using System.Collections;

/*
 * 		-this script contains the functions for playing footsteps when the 
 * 			player moves
 * 		-the functions are triggered from the PlayerMoter script
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
			Resources.Load("Sound/concrete1")   as AudioClip,
			Resources.Load("Sound/concrete2")   as AudioClip,
			Resources.Load("Sound/concrete4")   as AudioClip,
			Resources.Load("Sound/concrete6")   as AudioClip
			
		};
		
		// initialise walk logic
		walkSpeed = 0.4f;
		legPan = 0.3f;
		myAudio = GetComponent<AudioSource>();
		myAudio.spatialBlend = 0f; //use 2D audio (save uses of 3Dception)
		myAudio.reverbZoneMix = 1f; //use reverb zones
		myAudio.panStereo = -legPan; //left foot first (source panned 50% left)
		isLeftLeg = true;
		footFilter = GetComponent<AudioLowPassFilter>();
		filterCut = 5000;
		footFilter.cutoffFrequency = filterCut;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//called from PlayerMoter script when movement begins
	public void beginFootsteps(){

		InvokeRepeating("playFootsteps",walkSpeed,walkSpeed);
	}

	//called from PlayerMoter script when movement ends 
	public void stopFootsteps(){

		CancelInvoke("playFootsteps");
	}

	void playFootsteps(){
		
		// don't let clips overlap
		if(!myAudio.isPlaying)
		{

			// slightly vary filter cutoff for each step
			filterCut = Random.Range(4000, 6000);
			footFilter.cutoffFrequency = filterCut;

			// slightly vary pitch and volume of each sample
			myAudio.pitch = Random.Range(0.9f, 1.1f);
			myAudio.volume = Random.Range(0.6f, 1f);

			//pick random array index but don't repeat two in a row
			randomClip = Random.Range(0,4);
			while(randomClip == lastClip){
				randomClip = Random.Range(0,4);
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
				return;
			}

			//switch R to L
			if(!isLeftLeg){
				//play a random clip from the array
				myAudio.PlayOneShot(concreteFootsteps[randomClip]);
				//switch legs (stereo pan settings)
				myAudio.panStereo = -legPan;
				isLeftLeg = true;
				return;
			}
		}
		
	}
}


