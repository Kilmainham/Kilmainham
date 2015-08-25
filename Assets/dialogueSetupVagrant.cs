using UnityEngine;
using System.Collections;

public class dialogueSetupVagrant : MonoBehaviour {

	public AudioClip[] vagrantDialogueArray;
	public TBE_3DCore.TBE_Source vagrantAudioSource;
	
	// Use this for initialization
	void Start () {
		vagrantAudioSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		vagrantDialogueArray =  new AudioClip[]
		{	
			Resources.Load("Sound/Dialogue/vagrant/vagrantLine1")   as AudioClip,
			Resources.Load("Sound/Dialogue/vagrant/vagrantLine2")   as AudioClip
			
		};
		
	}
}
