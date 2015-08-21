using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {


		public int levelToLoad;
		
		public void ChangeLevel() {
			Application.LoadLevel(levelToLoad);
		}
		public void DelayedChangeLevel(){
		Invoke ("ChangeLevel", 2.5f);
		}
}

