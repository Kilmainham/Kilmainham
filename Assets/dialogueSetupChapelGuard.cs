using UnityEngine;
using System.Collections;

public class dialogueSetupChapelGuard : MonoBehaviour {

	public AudioClip[] chapelGuardDialogueArray;
	public TBE_3DCore.TBE_Source chapelGuardAudioSource;
	
	// Use this for initialization
	void Start () {
		chapelGuardAudioSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		chapelGuardDialogueArray =  new AudioClip[]
		{	
			Resources.Load("Sound/Dialogue/chapelGuard/chapelGuardLine1")   as AudioClip
		};
		
	}
}
