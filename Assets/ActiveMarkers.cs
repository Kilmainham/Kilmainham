using UnityEngine;
using System.Collections;

public class ActiveMarkers : MonoBehaviour {
	private GameObject[] locations;

	public int currentLevel;
	//This array should contain the names of all the navigable location levels. A Level is a collection of points which can be accessed at the same time from a given point.
	//From each point, all points in the level above and bellow are active. All other points are not.
	private string[] tags = new string[]{"Level0", "Level1", "Level2", "Level3"};
	/*ParticleSystem[] particles;
	void Start(){
		//DeactivateAllLevels ();
		//ActivateFirstLevel ();
		particles = GetComponents<ParticleSystem>;
		foreach (ParticleSystem particle in particles){
			if (particle.isPlaying) {
				particle.Stop();
			}
		}
	}*/


	public void DeactivateAllLevels(){
		locations = GameObject.FindGameObjectsWithTag ("LocationLevel");
		Debug.Log (locations);
		foreach (GameObject location in locations) {
			Debug.Log(location);
			location.SetActive(false);
		}


	}
	private void ActivateFirstLevel(){
		GameObject firstLevel = GameObject.Find( tags[1] ); //Not 0, this is where the player starts.
		firstLevel.SetActive(true);
	}
	public void ActivateMarkers(){
		if (true) {
			Debug.Log(GameObject.Find ("LocationContainer/Level1"));
			GameObject currentLevelObject = GameObject.Find (tags [currentLevel]);
			//currentLevelObject.SetActive (false);
			Debug.Log ("current level int = " + currentLevel);
		
			if (currentLevel != tags.GetLength (0)) {
				//Debug.Log("LocationContainer/"+tags [currentLevel + 1]);
				Debug.Log (GameObject.Find ("LocationContainer/"+tags [currentLevel + 1]));
				GameObject nextLevelObject = GameObject.Find (tags [currentLevel + 1]);
				nextLevelObject.SetActive (true);
			}
			if (currentLevel != 0) {
				Debug.Log("previous name ="+ tags [currentLevel - 1]);
				GameObject prevLevelObject = GameObject.Find (tags [currentLevel - 1]);
				prevLevelObject.SetActive (true);
			}
		}
	}




}
