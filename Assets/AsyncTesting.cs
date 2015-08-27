using UnityEngine;
using System.Collections;

public class AsyncTesting : MonoBehaviour {
	public static AsyncOperation async;
	void Start() {
		async = Application.LoadLevelAsync(5);
		async.allowSceneActivation = false;
		//yield return async;
		Debug.Log("Loading complete");
	}

	public void ChangeLevel(){
		async.allowSceneActivation = true;
	}
}