using UnityEngine;
using System.Collections;

public class GuardsFadeIn : MonoBehaviour {
	FadeObjectInOut fade;
	MegaCacheOBJ megaCache;
	public void fadeGhostsIn(){
		fade = gameObject.GetComponent<FadeObjectInOut> ();
		megaCache = gameObject.GetComponent<MegaCacheOBJ> ();
		megaCache.animate = true;
		fade.fadeTime = 0.5f;
		fade.FadeIn ();


	}


	public void fadeGhostsOut(){
		fade = gameObject.GetComponent<FadeObjectInOut> ();
		megaCache = gameObject.GetComponent<MegaCacheOBJ> ();
		megaCache.animate = false;
		fade.FadeOut ();
	}
}
