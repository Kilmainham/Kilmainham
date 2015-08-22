﻿using UnityEngine;
using System.Collections;

public class pointerColourChange : MonoBehaviour {
	GameObject pointer;
	Renderer rend;
	public bool gettingBigger;
	public bool gettingSmaller;
	ResizeGazePointer rgp;
	public float speed=0.05f;
	public float maxPointerSize=0.04f;
	public float minPointerSize=0.01f;
	public Color activeColour = Color.red;
	public Color inactiveColour = Color.white;

	void Start () {
		pointer = GameObject.Find("GazePointer");
		rend = pointer.GetComponent<Renderer> ();
		rgp = pointer.GetComponent<ResizeGazePointer> ();
		rend.material.color = Color.white;
		
	}
	void Update(){
		if (gettingBigger) {
			if (rgp.magconst<maxPointerSize){
				rgp.magconst+=speed*Time.deltaTime;

			}else{
				gettingBigger=false;
			}
		}
		if (gettingSmaller) {
			if(rgp.magconst>minPointerSize){
				rgp.magconst-=speed*Time.deltaTime;
			}else{
				gettingSmaller=false;
			}
		}
		if (gettingBigger && gettingSmaller) {
			gettingBigger=false;
			gettingSmaller=false;
		}
	}



	public void enter(){
		rend.material.color = activeColour;
		gettingBigger = true;
		gettingSmaller = false;
	}

	public void exit(){
		rend.material.color = inactiveColour;
		gettingSmaller = true;
		gettingBigger = false;
	}


}