using UnityEngine;
using System.Collections;

public class Flicker : MonoBehaviour {

	Light candleLight;
	GameObject candleObject;

	public float speed = 0.01f;
	public float topIntensity = 3.5f;
	public float bottomIntensity = 0.5f;

	float intensity;
	void Start () {
		candleObject = GameObject.Find ("CandleLight");
		candleLight = candleObject.GetComponent <Light>();
		intensity = bottomIntensity;
	}
	

	void Update () {
		candleLight.intensity = intensity;
		intensity =2f*( Mathf.PerlinNoise(Time.time*1.3f,0f));
	}
}
