using UnityEngine;
using System.Collections;

public class dialogueSetupTransport : MonoBehaviour {
	public AudioClip[] transportDialogueArray;
	public TBE_3DCore.TBE_Source transportAudioSource;

	// Use this for initialization
	void Start () {
		transportAudioSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		transportDialogueArray =  new AudioClip[]
		{	
			Resources.Load("Sound/transportLine1")   as AudioClip,
			Resources.Load("Sound/transportLine2")   as AudioClip,
			Resources.Load("Sound/transportLine3")   as AudioClip
			
		};
	}
}
