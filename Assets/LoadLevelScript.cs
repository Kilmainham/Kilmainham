using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
	public string levelToLoad;

	void OnMouseDown() {
		Application.LoadLevel(levelToLoad);
	}
}