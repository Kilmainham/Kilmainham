using UnityEngine;
using System.Collections;

public class Flicker : MonoBehaviour {

	Light candleLight;
	GameObject candleObject;

	public float speed = 0.01f;
	float topIntensity = 1.5f;
	float bottomIntensity = 0.5f;

	float intensity;
	void Start () {
		candleObject = GameObject.Find ("CandleLight");
		candleLight = candleObject.GetComponent <Light>();
		intensity = bottomIntensity;
	}
	

	void Update () {
		candleLight.intensity = intensity;
		intensity += speed;
		if (intensity > topIntensity || intensity < bottomIntensity) {
			speed = speed * -1;
		}

	}
}
