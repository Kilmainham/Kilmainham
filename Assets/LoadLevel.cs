using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {


	public int levelToLoad;
	public static AsyncOperation async;
	void Start(){
		async = Application.LoadLevelAsync(levelToLoad);
		async.allowSceneActivation = false;
	}

	public void ChangeLevel() {
		async.allowSceneActivation = true;
	}

	public void DelayedChangeLevel(){
		Invoke ("ChangeLevel", 2.5f);
	}
}

