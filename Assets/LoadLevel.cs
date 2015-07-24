using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {


		public string levelToLoad;
		
		public void ChangeLevel() {
			Application.LoadLevel(levelToLoad);
		}
}

