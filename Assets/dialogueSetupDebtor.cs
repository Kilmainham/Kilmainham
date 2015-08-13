using UnityEngine;
using System.Collections;

public class dialogueSetupDebtor : MonoBehaviour {
	public AudioClip[] debtorDialogueArray;
	public TBE_3DCore.TBE_Source debtorAudioSource;

	// Use this for initialization
	void Start () {
		debtorAudioSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		debtorDialogueArray =  new AudioClip[]
		{	
			Resources.Load("Sound/debtorLine1")   as AudioClip,
			Resources.Load("Sound/debtorLine2")   as AudioClip,
			Resources.Load("Sound/debtorLine3")   as AudioClip
			
		};
	
	}
}
