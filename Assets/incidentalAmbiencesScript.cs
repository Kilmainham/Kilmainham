using UnityEngine;
using System.Collections;

public class incidentalAmbiencesScript : MonoBehaviour {

	private GameObject[] sourceObjects;
	private AudioClip[] ambientClips;
 
	// Use this for initialization
	void Start () {
		sourceObjects = new GameObject[]{
			GameObject.Find ("source1"),
			GameObject.Find ("source2"),
			GameObject.Find ("source3"),
			GameObject.Find ("source4")

		};

		ambientClips =  new AudioClip[]
		{	
			Resources.Load("Sound/Ambiences/Incidental/Bang 1")   as AudioClip,
			Resources.Load("Sound/Ambiences/Incidental/Creak with Reverb 1")   as AudioClip,
			Resources.Load("Sound/Ambiences/Incidental/Distant Rattle 1")   as AudioClip,
			Resources.Load("Sound/Ambiences/Incidental/Ethereal Groan 1")   as AudioClip,
			Resources.Load("Sound/Ambiences/Incidental/High Rattle 1")   as AudioClip,
			Resources.Load("Sound/Ambiences/Incidental/Metallic 1")   as AudioClip,
			Resources.Load("Sound/Ambiences/Incidental/Scratch 1")   as AudioClip,

			
		};

		StartCoroutine(ambienceTrigger(true));
	
	}
	
	public IEnumerator ambienceTrigger(bool loop){

		while(loop){
			int theSource = Random.Range (0,4);
			int theClip = Random.Range (0,6);
			float timeDelay = Random.Range (5f,20f);

			sourceObjects[theSource].GetComponent<AudioSource>().volume = Random.Range(0.5f,1f);
			sourceObjects[theSource].GetComponent<AudioSource>().pitch = Random.Range(-1f,2f);
			sourceObjects[theSource].GetComponent<AudioSource>().PlayOneShot(ambientClips[theClip]);
			yield return new WaitForSeconds(timeDelay);

		}


	}
}
