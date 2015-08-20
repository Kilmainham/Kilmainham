using UnityEngine;
using System.Collections;

public class dialogueSetupGrace : MonoBehaviour {

	public AudioClip[] graceDialogueArray;
	public TBE_3DCore.TBE_Source graceAudioSource;
	
	// Use this for initialization
	void Start () {
		graceAudioSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		graceDialogueArray =  new AudioClip[]
		{	
			Resources.Load("Sound/Dialogue/grace/graceLine1")   as AudioClip,
			Resources.Load("Sound/Dialogue/grace/graceLine2")   as AudioClip,
			Resources.Load("Sound/Dialogue/grace/graceCrying")   as AudioClip

			
		};
			
	}
}
