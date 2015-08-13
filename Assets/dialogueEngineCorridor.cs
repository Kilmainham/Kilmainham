using UnityEngine;
using System.Collections;

public class dialogueEngineCorridor : MonoBehaviour {

	//setup character 1 = TRANSPORT
	public dialogueSetupTransport characterOneScript;
	public GameObject theTransport;
	public AudioClip[] charOneLines;
	public TBE_3DCore.TBE_Source charOneSource;
	
	//setup character 2 = DEBTOR
	public dialogueSetupDebtor characterTwoScript;
	public GameObject theDebtor;
	public AudioClip[] charTwoLines;
	public TBE_3DCore.TBE_Source charTwoSource;
	
	//setup character 3 = CULLEN
	public dialogueSetupCullen characterThreeScript;
	public GameObject cullenObj;
	public AudioClip[] charThreeLines;
	public TBE_3DCore.TBE_Source charThreeSource;
	
	//setup character 4 = NEARY
	public dialogueSetupNeary characterFourScript;
	public GameObject nearyObj;
	public AudioClip[] charFourLines;
	public TBE_3DCore.TBE_Source charFourSource;
	
	//setup character 5 = MADMAN
	public dialogueSetupMadman characterFiveScript;
	public GameObject madmanObj;
	public AudioClip[] charFiveLines;
	public TBE_3DCore.TBE_Source charFiveSource;
	
	//setup character 6 = VAGRANT
	public dialogueSetupVagrant characterSixScript;
	public GameObject vagrantObj;
	public AudioClip[] charSixLines;
	public TBE_3DCore.TBE_Source charSixSource;
	
	//setup character 7 = THIEF
	public dialogueSetupThief characterSevenScript;
	public GameObject thiefObj;
	public AudioClip[] charSevenLines;
	public TBE_3DCore.TBE_Source charSevenSource;
	
	
	//setup dialogue triggers for pseudo-callback functions
	public GameObject trigSceneA;
	public dialogueTriggerA scriptTrigSceneA;
	public GameObject trigSceneB;
	public dialogueTriggerB scriptTrigSceneB;
	public GameObject trigSceneC;
	public dialogueTriggerC scriptTrigSceneC;

	
	// setup some logic for handling interupts and restarts
	public bool sceneADialoguePlaying;
	public bool sceneADialoguePlayed;
	
	public bool sceneBDialoguePlaying;
	public bool sceneBDialoguePlayed;
	
	public bool sceneCDialoguePlaying;
	public bool sceneCDialoguePlayed;

	
	
	// setup dialogue parameters
	public int lineNumber;
	public float lineLength;
	public float linePause;
	//public float dramaticPause;
	
	
	// Use this for initialization
	void Awake () {

		//initialise scene A
		trigSceneA = GameObject.Find("Trigger A");
		scriptTrigSceneA = trigSceneA.GetComponent<dialogueTriggerA>();

		//initialise scene B
		trigSceneB = GameObject.Find("Trigger B");
		scriptTrigSceneB = trigSceneB.GetComponent<dialogueTriggerB>();

		//initialise scene C
		trigSceneC = GameObject.Find("Trigger C");
		scriptTrigSceneC = trigSceneC.GetComponent<dialogueTriggerC>();



		//initialise char 1
		theTransport = GameObject.Find("The Transport");
		charOneSource = theTransport.GetComponent<TBE_3DCore.TBE_Source>();
		charOneLines = theTransport.GetComponent<dialogueSetupTransport>().transportDialogueArray;

		//initialise char 2
		theDebtor = GameObject.Find("The Debtor");
		charTwoSource = theDebtor.GetComponent<TBE_3DCore.TBE_Source>();
		charTwoLines = theDebtor.GetComponent<dialogueSetupDebtor>().debtorDialogueArray;

		//initialise char 3
		cullenObj = GameObject.Find ("Cullen");
		charThreeSource = cullenObj.GetComponent<TBE_3DCore.TBE_Source>();
		charThreeLines = cullenObj.GetComponent<dialogueSetupCullen>().cullenDialogueArray;

		//initialise char 4
		nearyObj = GameObject.Find ("Neary");
		charFourSource = nearyObj.GetComponent<TBE_3DCore.TBE_Source>();
		charFourLines = nearyObj.GetComponent<dialogueSetupNeary>().nearyDialogueArray;

		//initialise char 5
		madmanObj = GameObject.Find ("Madman");
		charFiveSource = madmanObj.GetComponent<TBE_3DCore.TBE_Source>();
		charFiveLines = madmanObj.GetComponent<dialogueSetupMadman>().madmanDialogueArray;

		//initialise char 6
		vagrantObj = GameObject.Find ("Vagrant");
		charSixSource = vagrantObj.GetComponent<TBE_3DCore.TBE_Source>();
		charSixLines = vagrantObj.GetComponent<dialogueSetupVagrant>().vagrantDialogueArray;

		//initialise char 7
		thiefObj = GameObject.Find ("Thief");
		charSevenSource = thiefObj.GetComponent<TBE_3DCore.TBE_Source>();
		charSevenLines = thiefObj.GetComponent<dialogueSetupThief>().thiefDialogueArray;
				
		//initialise line params
		lineNumber = 0;
		linePause = 0.1f;
		
	}
	
	// reads in a clip and returns it length to use for setting wait times
	private float getCurrentClipLength(AudioClip clip){
		return clip.length;
	}
	
	public void triggerClipRoutine(int whichRoutine){
		//Corridors
		if (whichRoutine == 0 && sceneADialoguePlayed == false){
			StartCoroutine(playSceneA(3));
			Debug.Log ("COROUTINE A");
		}
		
		if (whichRoutine == 1 && sceneADialoguePlayed && sceneBDialoguePlayed == false){
			StartCoroutine(playSceneB(1));
			Debug.Log ("COROUTINE B");
		}
		
		if (whichRoutine == 2 && sceneBDialoguePlayed && sceneCDialoguePlayed == false){
			StartCoroutine(playSceneC(2));
			Debug.Log ("COROUTINE C");
		}
		
	}
	
	private void resetLogicAfterConversation(int conversation){
		
		if(conversation == 0){
			scriptTrigSceneA.externalCallbackDeactivate();
			scriptTrigSceneB.externalCallbackActivate();
			sceneADialoguePlaying = false;
			sceneADialoguePlayed = true;
			Debug.Log("RESET A");
		}
		
		if(conversation == 1){
			scriptTrigSceneB.externalCallbackDeactivate();
			scriptTrigSceneC.externalCallbackActivate();
			sceneBDialoguePlaying = false;
			sceneBDialoguePlayed = true;
			Debug.Log("RESET B");
		}
		
		if(conversation == 2){
			scriptTrigSceneC.externalCallbackDeactivate();
			sceneCDialoguePlaying = false;
			sceneCDialoguePlayed = true;
			Debug.Log("RESET C");
		}

		lineNumber = 0;

	}
	
	//the coroutine for the first conversation
	public IEnumerator playSceneA(int lineCount){
		
		while (lineNumber < lineCount){
			sceneADialoguePlaying = true;
			sceneADialoguePlayed = false;
			charOneSource.PlayOneShot(charOneLines[lineNumber]);
			lineLength = getCurrentClipLength(charOneLines[lineNumber]);
			yield return new WaitForSeconds((lineLength + linePause));
			
			charTwoSource.PlayOneShot(charTwoLines[lineNumber]);
			lineLength = getCurrentClipLength(charTwoLines[lineNumber]);
			lineNumber = lineNumber + 1;
			yield return new WaitForSeconds((lineLength + linePause));
		}
		
		resetLogicAfterConversation(0);
		
	}
	// the coroutine for the second conversation
	public IEnumerator playSceneB(int lineCount){
		
		sceneBDialoguePlaying = true;
		sceneBDialoguePlayed = false;
		
		charThreeSource.PlayOneShot(charThreeLines[lineNumber]);
		lineLength = getCurrentClipLength(charThreeLines[lineNumber]);
		yield return new WaitForSeconds((lineLength + linePause));
		
		charFourSource.PlayOneShot(charFourLines[lineNumber]);
		lineLength = getCurrentClipLength(charFourLines[lineNumber]);
		yield return new WaitForSeconds((lineLength + linePause));
		
		charFiveSource.PlayOneShot(charFiveLines[lineNumber]);
		lineLength = getCurrentClipLength(charFiveLines[lineNumber]);
		yield return new WaitForSeconds((lineLength + linePause));
		
		lineNumber = lineNumber + 1;
		
		charFourSource.PlayOneShot(charFourLines[lineNumber]);
		lineLength = getCurrentClipLength(charFourLines[lineNumber]);
		yield return new WaitForSeconds((lineLength + linePause));
		
		charThreeSource.PlayOneShot(charThreeLines[lineNumber]);
		lineLength = getCurrentClipLength(charThreeLines[lineNumber]);
		yield return new WaitForSeconds((lineLength + linePause));
		
		charFiveSource.PlayOneShot(charFiveLines[lineNumber]);
		lineLength = getCurrentClipLength(charFiveLines[lineNumber]);
		yield return new WaitForSeconds((lineLength + linePause));
		
		lineNumber = lineNumber + 1;
		
		charThreeSource.PlayOneShot(charThreeLines[lineNumber]);
		lineLength = getCurrentClipLength(charThreeLines[lineNumber]);
		yield return new WaitForSeconds((lineLength + linePause));
		
		
		resetLogicAfterConversation(1);
		
		
	}
	
	// the coroutine for the third conversation
	public IEnumerator playSceneC(int lineCount){
		
		while (lineNumber < lineCount){
			sceneCDialoguePlaying = true;
			sceneCDialoguePlayed = false;
			
			charSixSource.PlayOneShot(charSixLines[lineNumber]);
			lineLength = getCurrentClipLength(charSixLines[lineNumber]);
			yield return new WaitForSeconds((lineLength + linePause));
			
			charSevenSource.PlayOneShot(charSevenLines[lineNumber]);
			lineLength = getCurrentClipLength(charSevenLines[lineNumber]);
			lineNumber = lineNumber + 1;
			yield return new WaitForSeconds((lineLength + linePause));
		}
		
		resetLogicAfterConversation(2);
	}

}
