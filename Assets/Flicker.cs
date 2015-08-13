using UnityEngine;
using System.Collections;

public class Flicker : MonoBehaviour {

	Light candleLight;
	GameObject candleObject;

	public float speed = 0.01f;
	float topIntensity = 2.25f;
	float bottomIntensity = 1.0f;

	float intensity;
	// Use this for initialization
	void Start () {
		candleObject = GameObject.Find ("CandleLight");
		candleLight = candleObject.GetComponent <Light>();
		intensity = bottomIntensity;
	}
	
	// Update is called once per frame
	void Update () {
		candleLight.intensity = intensity;
		intensity += speed;
		if (intensity > topIntensity || intensity < bottomIntensity) {
			speed = speed * -1;
		}
		//Debug.Log ("Flickerscript. candleLight.intensity"+candleLight.intensity);
	}
}
