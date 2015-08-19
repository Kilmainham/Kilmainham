using UnityEngine;
using System.Collections;

public class dialogueEngineChapel : MonoBehaviour {

	//setup character 11 = GRACE
	public dialogueSetupGrace characterElevenScript;
	public GameObject graceObj;
	public AudioClip[] charElevenLines;
	public TBE_3DCore.TBE_Source charElevenSource;
	
	//setup character 12 = CHAPEL GUARD
	public dialogueSetupChapelGuard characterTwelveScript;
	public GameObject chapelGuardObj;
	public AudioClip[] charTwelveLines;
	public TBE_3DCore.TBE_Source charTwelveSource;
	
	//setup character 13 = JOSEPH
	public dialogueSetupJoseph characterThirteenScript;
	public GameObject josephObj;
	public AudioClip[] charThirteenLines;
	public TBE_3DCore.TBE_Source charThirteenSource;

	//setup character 14 = PRIEST
	public dialogueSetupPriest characteFourteenScript;
	public GameObject priestObj;
	public AudioClip[] charFourteenLines;
	public TBE_3DCore.TBE_Source charFourteenSource;

	//setup object 1 = ORGAN
	public dialogueSetupOrgan organScript;
	public GameObject organObj;
	public AudioClip[] organLines;
	public TBE_3DCore.TBE_Source organSource;


	//setup dialogue triggers for pseudo-callback functions
	public GameObject trigSceneE;
	public dialogueTriggerE scriptTrigSceneE;

	public GameObject trigSceneF;
	public dialogueTriggerF scriptTrigSceneF;

	
	
	// setup some logic for handling interupts and restarts
	public bool sceneEDialoguePlaying;
	public bool sceneEDialoguePlayed;

	public bool sceneFDialoguePlaying;
	public bool sceneFDialoguePlayed;


	
	
	
	// setup dialogue parameters
	public int lineNumber;
	public float lineLength;
	public float linePause;
	//public float dramaticPause;
	
	
	// Use this for initialization
	void Awake () {
		
		//initialise scene E
		trigSceneE = GameObject.Find("Trigger E");
		scriptTrigSceneE = trigSceneE.GetComponent<dialogueTriggerE>();

		//initialise scene F
		trigSceneF = GameObject.Find("Trigger F");
		scriptTrigSceneF = trigSceneF.GetComponent<dialogueTriggerF>();

		//initialise char 11
		graceObj = GameObject.Find("Grace");
		charElevenSource = graceObj.GetComponent<TBE_3DCore.TBE_Source>();
		charElevenLines = graceObj.GetComponent<dialogueSetupGrace>().graceDialogueArray;
		
		//initialise char 12
		chapelGuardObj = GameObject.Find("Chapel Guard");
		charTwelveSource = chapelGuardObj.GetComponent<TBE_3DCore.TBE_Source>();
		charTwelveLines = chapelGuardObj.GetComponent<dialogueSetupChapelGuard>().chapelGuardDialogueArray;
		
		//initialise char 13
		josephObj = GameObject.Find("Joseph");
		charThirteenSource = josephObj.GetComponent<TBE_3DCore.TBE_Source>();
		charThirteenLines = josephObj.GetComponent<dialogueSetupJoseph>().josephDialogueArray;

		//initialise char 14
		priestObj = GameObject.Find("Priest");
		charFourteenSource = priestObj.GetComponent<TBE_3DCore.TBE_Source>();
		charFourteenLines = priestObj.GetComponent<dialogueSetupPriest>().priestDialogueArray;

		//initialise organ object 
		organObj = GameObject.Find("Organ");
		organSource = organObj.GetComponent<TBE_3DCore.TBE_Source>();
		organLines = organObj.GetComponent<dialogueSetupOrgan>().organArray;
				
		//initialise line params
		lineNumber = 0;
		linePause = 0.1f;
		
	}
	
	// reads in a clip and returns it length to use for setting wait times
	private float getCurrentClipLength(AudioClip clip){
		return clip.length;
	}
	
	public void triggerClipRoutine(int whichRoutine){
		//Chapel Part 1
		if (whichRoutine == 4 && sceneEDialoguePlayed == false){
			StartCoroutine(playSceneE(1));
			Debug.Log ("COROUTINE E");
		}

		//Chapel Part 2
		if (whichRoutine == 5 && sceneFDialoguePlayed == false){
			StartCoroutine(playSceneF(1));
			Debug.Log ("COROUTINE F");
		}



		
	}
	
	private void resetLogicAfterConversation(int conversation){
		
		if(conversation == 4){
			scriptTrigSceneE.externalCallbackDeactivate();
			sceneEDialoguePlaying = false;
			sceneEDialoguePlayed = true;
			//scriptTrigSceneF.externalCallbackActivate();
			Debug.Log("RESET E");
		}

		if(conversation == 5){
			scriptTrigSceneF.externalCallbackDeactivate();
			sceneFDialoguePlaying = false;
			sceneFDialoguePlayed = true;
			Debug.Log("RESET F");
		}
		lineNumber = 0;
		
	}

	public void stopGraceCrying(){
		charElevenSource.loop = false;
		charElevenSource.Stop();
	}


	// the coroutine for the first conversation
	public IEnumerator playSceneE(int lineCount){
		
		sceneEDialoguePlaying = true;
		sceneEDialoguePlayed = false;
		
		charElevenSource.PlayOneShot(charElevenLines[lineNumber]);
		lineLength = getCurrentClipLength(charElevenLines[lineNumber]);
		yield return new WaitForSeconds((lineLength + linePause));

		charTwelveSource.PlayOneShot(charTwelveLines[lineNumber]);
		lineLength = getCurrentClipLength(charTwelveLines[lineNumber]);
		yield return new WaitForSeconds((lineLength + linePause));


		lineNumber = lineNumber + 1;

		charElevenSource.PlayOneShot(charElevenLines[lineNumber]);
		lineLength = getCurrentClipLength(charElevenLines[lineNumber]);
		yield return new WaitForSeconds((lineLength + linePause));

		lineNumber = lineNumber + 1;

		//grace crying starts here
		charElevenSource.loop = true;
		charElevenSource.clip = charElevenLines[lineNumber];
		charElevenSource.Play();

		//joseph's lines while grace is crying
		charThirteenSource.PlayOneShot(charThirteenLines[0]);
		lineLength = getCurrentClipLength(charThirteenLines[0]);
		yield return new WaitForSeconds((lineLength + linePause));

		//at this point, the challenge is activated
		scriptTrigSceneE.externalChallengeActivate();

		//lineLength = getCurrentClipLength(charElevenLines[lineNumber]);
		//yield return new WaitForSeconds((lineLength + linePause));

		//trigger this from external action maybe
		//charElevenSource.loop = false;
		//charElevenSource.Stop();

		resetLogicAfterConversation(4);
	}

	// the coroutine for the second conversation
	public IEnumerator playSceneF(int lineCount){
		
		sceneFDialoguePlaying = true;
		sceneFDialoguePlayed = false;
		//play priest lines
		charFourteenSource.PlayOneShot(charFourteenLines[lineNumber]);
		//play organ music
		organSource.PlayOneShot(organLines[lineNumber]);
		lineLength = getCurrentClipLength(organLines[lineNumber]);
		yield return new WaitForSeconds((lineLength + linePause));
		
		resetLogicAfterConversation(5);
	}

}
