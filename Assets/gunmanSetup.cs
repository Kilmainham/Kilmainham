using UnityEngine;
using System.Collections;

public class gunmanSetup : MonoBehaviour {

	public AudioClip[] shotsArray;
	public AudioClip[] reloadArray;
	public TBE_3DCore.TBE_Source gunmanSource;
	
	// Use this for initialization
	void Start () {
		gunmanSource = gameObject.GetComponent<TBE_3DCore.TBE_Source>();
		shotsArray =  new AudioClip[]
		{	
			Resources.Load("Sound/Guns/Shots/ComboFire1")   as AudioClip,
			Resources.Load("Sound/Guns/Shots/ComboFire2")   as AudioClip,
			Resources.Load("Sound/Guns/Shots/ComboFire3")   as AudioClip,
			Resources.Load("Sound/Guns/Shots/ComboFire4")   as AudioClip,
			Resources.Load("Sound/Guns/Shots/ComboFire5")   as AudioClip,
			Resources.Load("Sound/Guns/Shots/ComboFire6")   as AudioClip,
			Resources.Load("Sound/Guns/Shots/ComboFire7")   as AudioClip,
			Resources.Load("Sound/Guns/Shots/ComboFire8")   as AudioClip,
			Resources.Load("Sound/Guns/Shots/ComboFire9")   as AudioClip,
			Resources.Load("Sound/Guns/Shots/ComboFire10")   as AudioClip,
			Resources.Load("Sound/Guns/Shots/ComboFire11")   as AudioClip,
			Resources.Load("Sound/Guns/Shots/ComboFire12")   as AudioClip
		};

		reloadArray =  new AudioClip[]
		{	
			Resources.Load("Sound/Guns/Reload/Cocking1")   as AudioClip,
			Resources.Load("Sound/Guns/Reload/Cocking2")   as AudioClip,
			Resources.Load("Sound/Guns/Reload/Cocking3")   as AudioClip,
			Resources.Load("Sound/Guns/Reload/Cocking4")   as AudioClip,
			Resources.Load("Sound/Guns/Reload/Cocking5")   as AudioClip,
			Resources.Load("Sound/Guns/Reload/Cocking6")   as AudioClip
		};
		
	}
}
