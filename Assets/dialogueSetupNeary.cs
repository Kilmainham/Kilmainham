using UnityEngine;
using System.Collections;

public class dialogueSetupNeary : MonoBehaviour {

	public AudioClip[] nearyDialogueArray;
	public TBE_3DCore.TBE_Source nearyAudioSource;
	
	// Use this for initialization
	void Start () {
		nearyAudioSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		nearyDialogueArray =  new AudioClip[]
		{	
			Resources.Load("Sound/nearyLine1")   as AudioClip,
			Resources.Load("Sound/nearyLine2")   as AudioClip
			
		};
		
	}
}
