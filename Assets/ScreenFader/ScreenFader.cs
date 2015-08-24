using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {
	//public GameObject fader;
	Renderer rend;
	public Color faderColor;
	public float alpha = 1.0f;
	public bool fadingIn = true;
	public bool fadingOut = false;
	// Use this for initialization
	
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
		
		faderColor = new Color (0f, 0f, 0f, alpha);
		alpha = alpha - 0.01f;
		rend.material.color = faderColor;
		if (alpha <= 0f) {
			rend.enabled=false;
			fadingIn=false;
		}
		
	}
	
	void fadeOut(){
		
		rend.enabled = true;
		faderColor = new Color (0f, 0f, 0f, alpha);
		rend.material.color = faderColor;
		if (alpha < 1f) {
			alpha = alpha + 0.01f;
		}
	}
	public void startFadeOut(){
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