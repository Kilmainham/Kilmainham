using UnityEngine;
using System.Collections;

public class PriestFade : MonoBehaviour {

	FadeObjectInOut fade;
	MegaCacheOBJ megaCache;
	
	public void fadePriestIn(){
		fade = gameObject.GetComponent<FadeObjectInOut> ();
		megaCache = gameObject.GetComponent<MegaCacheOBJ> ();
		fade.FadeIn ();
		megaCache.animate = true;
	}
}
