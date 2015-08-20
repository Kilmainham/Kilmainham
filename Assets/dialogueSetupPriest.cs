using UnityEngine;
using System.Collections;

public class dialogueSetupPriest : MonoBehaviour {

	public AudioClip[] priestDialogueArray;
	public TBE_3DCore.TBE_Source priestAudioSource;
	
	// Use this for initialization
	void Start () {
		priestAudioSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		priestDialogueArray =  new AudioClip[]
		{	
			Resources.Load("Sound/Dialogue/priest/priestLine1")   as AudioClip
		};
		
	}
}
