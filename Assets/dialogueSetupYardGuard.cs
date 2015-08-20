using UnityEngine;
using System.Collections;

public class dialogueSetupYardGuard : MonoBehaviour {

	public AudioClip[] yardGuardDialogueArray;
	public TBE_3DCore.TBE_Source yardGuardAudioSource;
	
	// Use this for initialization
	void Start () {
		yardGuardAudioSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		yardGuardDialogueArray =  new AudioClip[]
		{	
			Resources.Load("Sound/Dialogue/yardGuard/guardYardLine1")   as AudioClip,
			Resources.Load("Sound/Dialogue/yardGuard/guardYardLine2")   as AudioClip,
			Resources.Load("Sound/Dialogue/yardGuard/guardYardLine3")   as AudioClip,
			Resources.Load("Sound/Dialogue/yardGuard/guardYardLine4")   as AudioClip,
			Resources.Load("Sound/Dialogue/yardGuard/guardYardLine5")   as AudioClip,
			Resources.Load("Sound/Dialogue/yardGuard/guardYardLine6")   as AudioClip,
			Resources.Load("Sound/Dialogue/yardGuard/guardYardLine7")   as AudioClip,
			Resources.Load("Sound/Dialogue/yardGuard/guardYardLine8")   as AudioClip,
			Resources.Load("Sound/Dialogue/yardGuard/guardYardLine9")   as AudioClip,
			Resources.Load("Sound/Dialogue/yardGuard/guardYardLine10")   as AudioClip,
			Resources.Load("Sound/Dialogue/yardGuard/guardYardLine11")   as AudioClip,
			Resources.Load("Sound/Dialogue/yardGuard/guardYardLine12")   as AudioClip,
			Resources.Load("Sound/Dialogue/yardGuard/guardYardLine13")   as AudioClip,
			Resources.Load("Sound/Dialogue/yardGuard/guardYardLine14")   as AudioClip


		};
		
	}
}
