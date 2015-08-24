using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {
	
	public float speed = 0.01f;
	
	// Update is called once per frame
	void Update () {
		float newPositionY = transform.position.y+speed;
		transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);		

		if (newPositionY >= 77f) {
			GameObject screenfader = GameObject.Find("CreditsScreenFader");
			ScreenFader screenFaderScript = (ScreenFader) screenfader.GetComponent(typeof(ScreenFader));
			screenFaderScript.startFadeOut();
			if (screenFaderScript.FadeOutIsComplete()) {
				Application.LoadLevel("SplashScreen_scene1_menu");
			}
		}
	}
}
