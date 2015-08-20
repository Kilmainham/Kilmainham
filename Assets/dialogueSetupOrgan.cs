using UnityEngine;
using System.Collections;

public class dialogueSetupOrgan : MonoBehaviour {

	public AudioClip[] organArray;
	public TBE_3DCore.TBE_Source organSource;
	
	// Use this for initialization
	void Start () {
		organSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		organArray =  new AudioClip[]
		{	
			Resources.Load("Sound/Objects/Chapel Organ")   as AudioClip
		};
		
	}
}
