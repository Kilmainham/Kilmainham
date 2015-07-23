using UnityEngine;
using System.Collections;

public class ActiveMarkers : MonoBehaviour {

	public int currentLevel;
	public FadeObjectInOut fade;
	public CapsuleCollider collider;
	//This array should contain the names of all the navigable location levels. A Level is a collection of points which can be accessed at the same time from a given point.
	//From each point, all points in the level above and bellow are active. All other points are not.
	private string[] tags = new string[]{"Level0", "Level1", "Level2", "Level3"};
	void AddFadeComponents(){
		for (int i = 0; i<tags.Length; i++) {
			GameObject[] levelMarkers = GameObject.FindGameObjectsWithTag (tags [i]);
			foreach (GameObject marker in levelMarkers) {
				marker.AddComponent<FadeObjectInOut> ();
			}
		}
	}

	void FadeAllOut(){
		//fades out all markers
		for (int i=0; i<tags.Length; i++) {
			GameObject[] levelMarkers = GameObject.FindGameObjectsWithTag(tags[i]);
			foreach (GameObject marker in levelMarkers){
				fade = marker.GetComponentInChildren<FadeObjectInOut>();
				fade.FadeOut();
				collider = marker.GetComponentInChildren<CapsuleCollider>();
				collider.enabled=false;
			}
		}
	}
	void Start(){
		AddFadeComponents ();
		FadeAllOut ();
		//fade in the first level markers
		GameObject[] level1 = GameObject.FindGameObjectsWithTag(tags[1]);
		foreach (GameObject marker in level1){
			fade = marker.GetComponentInChildren<FadeObjectInOut>();
			fade.FadeIn();
			collider = marker.GetComponentInChildren<CapsuleCollider>();
			collider.enabled=true;
		}
	}

	public void ActivateMarkers(){
		FadeAllOut();
		string currentLevelString = tags [currentLevel];
		Debug.Log (currentLevel);

		GameObject[] currentMarkers = GameObject.FindGameObjectsWithTag(currentLevelString);
		foreach (GameObject marker in currentMarkers) {

			fade = marker.GetComponentInChildren<FadeObjectInOut>();
			fade.FadeOut ();
			collider = marker.GetComponentInChildren<CapsuleCollider>();
			collider.enabled=false;
			Debug.Log ("Current level faded out");

		}
		if (currentLevel > 0) {
			string previousLevelString = tags [currentLevel-1];
			GameObject[] previousMarkers = GameObject.FindGameObjectsWithTag(previousLevelString);
			foreach (GameObject marker in previousMarkers){
				fade = marker.GetComponentInChildren<FadeObjectInOut>();
				fade.FadeIn();
				collider = marker.GetComponentInChildren<CapsuleCollider>();
				collider.enabled=true;
				Debug.Log ("Previous level faded in");
			}
		
		}

		if (currentLevel < tags.Length-1) {
			string nextLevelString = tags[currentLevel+1];
			GameObject[] nextMarkers = GameObject.FindGameObjectsWithTag(nextLevelString);
			foreach (GameObject marker in nextMarkers ){
				fade = marker.GetComponentInChildren<FadeObjectInOut>();
				fade.FadeIn();
				collider = marker.GetComponentInChildren<CapsuleCollider>();
				collider.enabled=true;
				Debug.Log ("Next level faded in");
			}
		}

	}




}
