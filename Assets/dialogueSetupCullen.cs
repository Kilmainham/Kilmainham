using UnityEngine;
using System.Collections;

public class dialogueSetupCullen : MonoBehaviour {

	public AudioClip[] cullenDialogueArray;
	public TBE_3DCore.TBE_Source cullenAudioSource;
	
	// Use this for initialization
	void Start () {
		cullenAudioSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		cullenDialogueArray =  new AudioClip[]
		{	
			Resources.Load("Sound/cullenLine1")   as AudioClip,
			Resources.Load("Sound/cullenLine2")   as AudioClip,
			Resources.Load("Sound/cullenLine3")   as AudioClip
			
		};
		
	}
}
