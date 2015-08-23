using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SplashScreenManagerScript : MonoBehaviour {

	private ScreenFader screenfader; 

	private List<GameObject> splashScreens = new List<GameObject>();

	private int currentSplashScreenIndex;
	
	private float timePerSplashScreen = 3f;
	private float timer;
	

	void Awake () {
		GameObject trinityLogoObject = GameObject.Find ("TrinityLogo");
		GameObject canvasSplashScreenObject = GameObject.Find ("CanvasSplashScreen");
		GameObject kilmainhamLogoObject = GameObject.Find ("KilmainhamLogo");

		//Here you add 3 objects to the List
		splashScreens.Add(trinityLogoObject);
		splashScreens.Add(canvasSplashScreenObject);
		splashScreens.Add(kilmainhamLogoObject);

		GameObject fader = GameObject.Find ("ScreenFader");
		screenfader = (ScreenFader)fader.GetComponent(typeof(ScreenFader));
	}

	// Use this for initialization
	void Start () {
		currentSplashScreenIndex = 0;
		disablePreviousEnableCurrentSS ();
		screenfader.startFadeIn ();
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= timePerSplashScreen && screenfader.fadingOut == false){
			screenfader.startFadeOut();
		}

		if (screenfader.FadeInIsComplete()) {
			timer = timer + Time.deltaTime;
		}

		if (timer > 0f && screenfader.FadeOutIsComplete()) {
			if (currentSplashScreenIndex == splashScreens.Count - 1) {
				//load next scene:
			}
			else {
				nextSplashScreen();
			}
		}
	}

	void nextSplashScreen (){
		if (currentSplashScreenIndex + 1 < splashScreens.Count){
			currentSplashScreenIndex = currentSplashScreenIndex + 1;
		}
		disablePreviousEnableCurrentSS ();
		screenfader.startFadeIn ();
		timer = 0f;
	}

	private void disablePreviousEnableCurrentSS() {
		//disable previous splashscreen
		if(currentSplashScreenIndex - 1 >= 0){
			disableEnableRenderingComponent(splashScreens[currentSplashScreenIndex - 1], false);
		}
		//enable current splashscreen
		if(currentSplashScreenIndex < splashScreens.Count){
			disableEnableRenderingComponent(splashScreens[currentSplashScreenIndex], true);
		}
	}

	private void disableEnableRenderingComponent(GameObject go, bool toBeEnabled){
		if (go.GetComponent<MeshRenderer>() != null) {
			go.GetComponent<MeshRenderer>().enabled = toBeEnabled;
		}
		else if (go.GetComponent<Canvas>() != null){
			go.GetComponent<Canvas>().enabled = toBeEnabled;
		}
	}
}
