using UnityEngine;
using System.Collections;

public class entryDoorAudio : MonoBehaviour {
	private AudioSource entryDoorAudioSource;

	// Use this for initialization
	void Start () {
		entryDoorAudioSource = GetComponent<AudioSource> ();
		entryDoorAudioSource.PlayDelayed (2f);
	}
	

}
