using UnityEngine;
using System.Collections;

public class dialogueSetupMadman : MonoBehaviour {

	public AudioClip[] madmanDialogueArray;
	public TBE_3DCore.TBE_Source madmanAudioSource;
	
	// Use this for initialization
	void Start () {
		madmanAudioSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		madmanDialogueArray =  new AudioClip[]
		{	
			Resources.Load("Sound/madmanLine1")   as AudioClip,
			Resources.Load("Sound/madmanLine2")   as AudioClip
			
		};
		
	}
}
