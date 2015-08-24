using UnityEngine;
using System.Collections;

public class fadeVolume : MonoBehaviour {

	enum Fade {In, Out};
	float fadeTime = 1f;
	

	public void triggerFade(){
			StartCoroutine(FadeAudio(fadeTime, Fade.Out));
		}

	void Start (){
		StartCoroutine(FadeAudio(fadeTime, Fade.In));
	}

	IEnumerator FadeAudio (float timer, Fade fadeType) {
		float start = fadeType == Fade.In? 0.0F : 1.0f;
		float end = fadeType == Fade.In? 1.0f : 0.0f;
		float i = 0.0f;
		float step = 1.0f/timer;
		
		while (i <= 1.0f) {
			i += step * Time.deltaTime;
			AudioListener.volume = Mathf.Lerp(start, end, i);
			yield return new WaitForSeconds(step * Time.deltaTime);
		}
	}
}


