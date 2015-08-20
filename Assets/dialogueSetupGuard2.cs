using UnityEngine;
using System.Collections;

public class dialogueSetupGuard2 : MonoBehaviour {

	public AudioClip[] guard2DialogueArray;
	public TBE_3DCore.TBE_Source guard2AudioSource;
	
	// Use this for initialization
	void Start () {
		guard2AudioSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		guard2DialogueArray =  new AudioClip[]
		{	
			Resources.Load("Sound/Dialogue/eastWingGuards/guard2Line1")   as AudioClip
			
		};
		
	}
}
