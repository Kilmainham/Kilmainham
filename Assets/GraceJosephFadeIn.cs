using UnityEngine;
using System.Collections;

public class GraceJosephFadeIn : MonoBehaviour {

	FadeObjectInOut fade;
	MegaCacheOBJ megaCache;

	public void fadeGraceJosephIn(){
		fade = gameObject.GetComponent<FadeObjectInOut> ();
		megaCache = gameObject.GetComponent<MegaCacheOBJ> ();
		fade.FadeIn ();
		megaCache.animate = true;
	}

}
