using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {
	//public GameObject fader;
	Renderer rend;
	public Color faderColor;
	public float alpha = 1.0f;
	public bool fadingIn = true;
	public bool fadingOut = false;

	public float speed= 0.5f;
	//controls for fader colour
	float r=0f;
	float g=0f;
	float b=0f;
	
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		//fader = GameObject.Find ("ScreenFader");
		//rend = fader.GetComponent<Renderer> ();
		rend = gameObject.GetComponent<Renderer> ();
		rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(fadingIn){
			fadeIn();				
		}
		if (fadingOut) {
			fadeOut ();
		}
		
	}
	
	void fadeIn(){
		
		faderColor = new Color (r, g, b, alpha);
		alpha = alpha - speed*Time.deltaTime;
		rend.material.color = faderColor;
		if (alpha <= 0f) {
			rend.enabled=false;
			fadingIn=false;
		}
		
	}
	
	void fadeOut(){
		
		rend.enabled = true;
		faderColor = new Color (r, g, b, alpha);
		rend.material.color = faderColor;
		if (alpha < 1f) {
			alpha = alpha + speed*Time.deltaTime;
		}
	}
	public void startFadeOut(){
		r = g = b = 0f;
		fadingOut = true;
		fadingIn = false;
	}

	public void startFadetoWhite(){
		r = g = b = 1f;
		fadingOut = true;
		fadingIn = false;
	}

	public void startFadeIn(){
		fadingIn = true;
		fadingOut = false;
	}
	
	//return true if fadeIn is complete
	public bool FadeInIsComplete () {
		return alpha <=0f;
		
	}
	// return true if fadeOut is complete
	public bool FadeOutIsComplete () {
		return alpha >=1f;
		
	}
}