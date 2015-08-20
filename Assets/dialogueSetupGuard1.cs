using UnityEngine;
using System.Collections;

public class dialogueSetupGuard1 : MonoBehaviour {

	public AudioClip[] guard1DialogueArray;
	public TBE_3DCore.TBE_Source guard1AudioSource;
	
	// Use this for initialization
	void Start () {
		guard1AudioSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		guard1DialogueArray =  new AudioClip[]
		{	
			Resources.Load("Sound/Dialogue/eastWingGuards/guard1Line1")   as AudioClip,
			Resources.Load("Sound/Dialogue/eastWingGuards/guard1Line2")   as AudioClip
			
		};
		
	}
}
