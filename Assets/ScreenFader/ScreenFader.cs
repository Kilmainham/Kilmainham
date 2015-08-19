using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {
	public GameObject fader;
	Renderer rend;
	public Material black;
	public Material clear;
	public Shader shader;
	public Color faderColor;
	public float alpha = 1.0f;
	public bool fadingIn = true;
	public bool fadingOut = false;
	// Use this for initialization
	void Start () {
		fader = GameObject.Find ("ScreenFader");
		rend = fader.GetComponent<Renderer> ();
		black = new Material(shader );
		black.color=Color.black;
		clear= new Material(shader);
		clear.color=Color.clear;

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

	public void fadeIn(){

		faderColor = new Color (0f, 0f, 0f, alpha);
		alpha = alpha - 0.01f;
		rend.material.color = faderColor;
		if (alpha <= 0f) {
			rend.enabled=false;
			fadingIn=false;
		}

	}

	public void fadeOut(){

		rend.enabled = true;
		faderColor = new Color (0f, 0f, 0f, alpha);
		rend.material.color = faderColor;
		if (alpha < 1f) {
			alpha = alpha + 0.01f;
		}
	}
	public void startFadeOut(){
		fadingOut = true;
	}
}
