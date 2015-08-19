using UnityEngine;
using System.Collections;

public class dialogueSetupJoseph : MonoBehaviour {

	public AudioClip[] josephDialogueArray;
	public TBE_3DCore.TBE_Source josephAudioSource;
	
	// Use this for initialization
	void Start () {
		josephAudioSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		josephDialogueArray =  new AudioClip[]
		{	
			Resources.Load("Sound/Dialogue/joseph/josephLine1")   as AudioClip
		};
		
	}
}
