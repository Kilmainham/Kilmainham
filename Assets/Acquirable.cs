using UnityEngine;
using System.Collections;

public class Acquirable : MonoBehaviour {

	private bool acquired = false;
	private AudioSource keyAudio;





	// Use this for initialization
	void Start () {
		keyAudio = GetComponent<AudioSource>();
	
	}

	public void Acquire (){
		acquired = true;
		GameObject acquiredObject = GameObject.Find("AcquiredObjectPosition");
		transform.position = acquiredObject.transform.position;
		transform.parent = acquiredObject.transform;
		keyAudio.Play();
	}
	
	// Update is called once per frame
	/*void Update () {
		if (Input.GetMouseButtonDown(0)){
			Acquire();
			Debug.Log("Acquire CANDLE.");
		}
	
	}*/
}
