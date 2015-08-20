using UnityEngine;
using System.Collections;

public class dialogueSetupGuard3 : MonoBehaviour {

	public AudioClip[] guard3DialogueArray;
	public TBE_3DCore.TBE_Source guard3AudioSource;
	
	// Use this for initialization
	void Start () {
		guard3AudioSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		guard3DialogueArray =  new AudioClip[]
		{	
			Resources.Load("Sound/Dialogue/eastWingGuards/guard3Line1")   as AudioClip,
			Resources.Load("Sound/Dialogue/eastWingGuards/guard3Line1b")   as AudioClip

			
		};
		
	}
}
