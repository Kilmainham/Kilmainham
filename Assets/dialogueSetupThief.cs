using UnityEngine;
using System.Collections;

public class dialogueSetupThief : MonoBehaviour {

	public AudioClip[] thiefDialogueArray;
	public TBE_3DCore.TBE_Source thiefAudioSource;
	
	// Use this for initialization
	void Start () {
		thiefAudioSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		thiefDialogueArray =  new AudioClip[]
		{	
			Resources.Load("Sound/Dialogue/thief/thiefLine1")   as AudioClip,
			Resources.Load("Sound/Dialogue/thief/thiefLine2")   as AudioClip
			
		};
		
	}
}
