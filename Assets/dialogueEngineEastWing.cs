using UnityEngine;
using System.Collections;

public class dialogueEngineEastWing : MonoBehaviour {
	// Ghosts

	public GameObject guard12Ghost;
	public GuardsFadeIn guards12Fade;

	public GameObject guard3Ghost;
	public GuardsFadeIn guards3Fade;


	//setup character 8 = GUARD 1
	public dialogueSetupGuard1 characterEightScript;
	public GameObject guard1Obj;
	public AudioClip[] charEightLines;
	public TBE_3DCore.TBE_Source charEightSource;
	
	//setup character 9 = GUARD 2
	public dialogueSetupGuard2 characterNineScript;
	public GameObject guard2Obj;
	public AudioClip[] charNineLines;
	public TBE_3DCore.TBE_Source charNineSource;
	
	//setup character 10 = GUARD 3
	public dialogueSetupGuard3 characterTenScript;
	public GameObject guard3Obj;
	public AudioClip[] charTenLines;
	public TBE_3DCore.TBE_Source charTenSource; 
	
	
	
	//setup dialogue triggers for pseudo-callback functions
	public GameObject trigSceneD;
	public dialogueTriggerD scriptTrigSceneD;
	
	
	// setup some logic for handling interupts and restarts	
	public bool sceneDDialoguePlaying;
	public bool sceneDDialoguePlayed;
	
	
	// setup dialogue parameters
	public int lineNumber;
	public float lineLength;
	public float linePause;
	//public float dramaticPause;
	
	
	// Use this for initialization
	void Awake () {
		//initiialise ghost mesh
		guard12Ghost = GameObject.Find ("Guards1+2");
		guards12Fade = guard12Ghost.GetComponent<GuardsFadeIn>();
		
		guard3Ghost = GameObject.Find ("Guard3Ghost");
		guards3Fade = guard3Ghost.GetComponent<GuardsFadeIn>();

		//initialise scene D
		trigSceneD = GameObject.Find("Trigger D");
		scriptTrigSceneD = trigSceneD.GetComponent<dialogueTriggerD>();

		//initialise char 8
		guard1Obj = GameObject.Find ("Guard 1");
		charEightSource = guard1Obj.GetComponent<TBE_3DCore.TBE_Source>();
		charEightLines = guard1Obj.GetComponent<dialogueSetupGuard1>().guard1DialogueArray;
		
		//initialise char 9
		guard2Obj = GameObject.Find ("Guard 2");
		charNineSource = guard2Obj.GetComponent<TBE_3DCore.TBE_Source>();
		charNineLines = guard2Obj.GetComponent<dialogueSetupGuard2>().guard2DialogueArray;
		
		//initialise char 10
		guard3Obj = GameObject.Find ("Guard 3");
		charTenSource = guard3Obj.GetComponent<TBE_3DCore.TBE_Source>();
		charTenLines = guard3Obj.GetComponent<dialogueSetupGuard3>().guard3DialogueArray;
		
		//initialise line params
		lineNumber = 0;
		linePause = 0.1f;
		
	}
	
	// reads in a clip and returns it length to use for setting wait times
	private float getCurrentClipLength(AudioClip clip){
		return clip.length;
	}
	
	public void triggerClipRoutine(int whichRoutine){
		//East Wing
		if (whichRoutine == 3 && sceneDDialoguePlayed == false){
			StartCoroutine(playSceneD(1));
			guards12Fade.fadeGhostsIn();
		}
	}
	
	private void resetLogicAfterConversation(int conversation){

		if(conversation == 3){
			scriptTrigSceneD.externalCallbackDeactivate();
			sceneDDialoguePlaying = false;
			sceneDDialoguePlayed = true;
		}
		lineNumber = 0;
	}

	void fadeOutGhosts(){
		guards12Fade.fadeGhostsOut();
	}
	//the coroutine for the fourth conversation
	public IEnumerator playSceneD(int lineCount){
		
		sceneDDialoguePlaying = true;
		sceneDDialoguePlayed = false;
		charEightSource.PlayOneShot(charEightLines[lineNumber]);
		lineLength = getCurrentClipLength(charEightLines[lineNumber]);
		yield return new WaitForSeconds((lineLength + linePause));
		
		charNineSource.PlayOneShot(charNineLines[lineNumber]);
		lineLength = getCurrentClipLength(charNineLines[lineNumber]);
		yield return new WaitForSeconds((lineLength + linePause));
		
		lineNumber = lineNumber + 1;



		charEightSource.PlayOneShot(charEightLines[lineNumber]);
		lineLength = getCurrentClipLength(charEightLines[lineNumber]);
		yield return new WaitForSeconds((lineLength + linePause));

		fadeOutGhosts ();
		yield return new WaitForSeconds(4f);

		guards3Fade.fadeGhostsIn ();

		charTenSource.PlayOneShot(charTenLines[0]);
		lineLength = getCurrentClipLength(charTenLines[0]);
		yield return new WaitForSeconds((lineLength + linePause + 6f));
		
		charTenSource.PlayOneShot(charTenLines[1]);
		lineLength = getCurrentClipLength(charTenLines[1]);
		yield return new WaitForSeconds((lineLength + linePause));		
		
		resetLogicAfterConversation(3);
	}
}
