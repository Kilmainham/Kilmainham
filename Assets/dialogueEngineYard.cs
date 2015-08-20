using UnityEngine;
using System.Collections;

public class dialogueEngineYard : MonoBehaviour {

	//setup character 15 = YARD GUARD
	public dialogueSetupYardGuard characterFifteenScript;
	public GameObject yardGuardObj;
	public AudioClip[] charFifteenLines;
	public TBE_3DCore.TBE_Source charFifteenSource;

	//setup GUNMAN 1
	public gunmanSetup gunman1Script;
	public GameObject gunman1Obj;
	public AudioClip[] gunman1Shots;
	public AudioClip[] gunman1Reload;
	public TBE_3DCore.TBE_Source gunman1Source;

	//setup GUNMAN 2
	public gunmanSetup gunman2Script;
	public GameObject gunman2Obj;
	public AudioClip[] gunman2Shots;
	public AudioClip[] gunman2Reload;
	public TBE_3DCore.TBE_Source gunman2Source;

	//setup GUNMAN 3
	public gunmanSetup gunman3Script;
	public GameObject gunman3Obj;
	public AudioClip[] gunman3Shots;
	public AudioClip[] gunman3Reload;
	public TBE_3DCore.TBE_Source gunman3Source;

	//setup GUNMAN 4
	public gunmanSetup gunman4Script;
	public GameObject gunman4Obj;
	public AudioClip[] gunman4Shots;
	public AudioClip[] gunman4Reload;
	public TBE_3DCore.TBE_Source gunman4Source;

	//setup GUNMAN 5
	public gunmanSetup gunman5Script;
	public GameObject gunman5Obj;
	public AudioClip[] gunman5Shots;
	public AudioClip[] gunman5Reload;
	public TBE_3DCore.TBE_Source gunman5Source;

	//setup GUNMAN 6
	public gunmanSetup gunman6Script;
	public GameObject gunman6Obj;
	public AudioClip[] gunman6Shots;
	public AudioClip[] gunman6Reload;
	public TBE_3DCore.TBE_Source gunman6Source;

	//setup GUNMAN 7
	public gunmanSetup gunman7Script;
	public GameObject gunman7Obj;
	public AudioClip[] gunman7Shots;
	public AudioClip[] gunman7Reload;
	public TBE_3DCore.TBE_Source gunman7Source;
		
	//setup dialogue triggers for pseudo-callback functions
	public GameObject trigSceneG;
	public dialogueTriggerG scriptTrigSceneG;
		
	// setup some logic for handling interupts and restarts
	public bool sceneGDialoguePlaying;
	public bool sceneGDialoguePlayed;
		
	// setup dialogue parameters
	public int lineNumber;
	public float lineLength;
	public float linePause;
	
	// Use this for initialization
	void Awake () {
		
		//initialise scene G
		trigSceneG = GameObject.Find("Trigger G");
		scriptTrigSceneG = trigSceneG.GetComponent<dialogueTriggerG>();

		
		//initialise char 11
		yardGuardObj = GameObject.Find("Yard Guard");
		charFifteenSource = yardGuardObj.GetComponent<TBE_3DCore.TBE_Source>();
		charFifteenLines = yardGuardObj.GetComponent<dialogueSetupYardGuard>().yardGuardDialogueArray;

		//initialise gunman 1
		gunman1Obj = GameObject.Find ("Gunman 1");
		gunman1Source = gunman1Obj.GetComponent<TBE_3DCore.TBE_Source>();
		gunman1Shots = gunman1Obj.GetComponent<gunmanSetup>().shotsArray;
		gunman1Reload = gunman1Obj.GetComponent<gunmanSetup>().reloadArray;

		//initialise gunman 2
		gunman2Obj = GameObject.Find ("Gunman 2");
		gunman2Source = gunman2Obj.GetComponent<TBE_3DCore.TBE_Source>();
		gunman2Shots = gunman2Obj.GetComponent<gunmanSetup>().shotsArray;
		gunman2Reload = gunman2Obj.GetComponent<gunmanSetup>().reloadArray;

		//initialise gunman 3
		gunman3Obj = GameObject.Find ("Gunman 3");
		gunman3Source = gunman3Obj.GetComponent<TBE_3DCore.TBE_Source>();
		gunman3Shots = gunman3Obj.GetComponent<gunmanSetup>().shotsArray;
		gunman3Reload = gunman3Obj.GetComponent<gunmanSetup>().reloadArray;

		//initialise gunman 4
		gunman4Obj = GameObject.Find ("Gunman 4");
		gunman4Source = gunman4Obj.GetComponent<TBE_3DCore.TBE_Source>();
		gunman4Shots = gunman4Obj.GetComponent<gunmanSetup>().shotsArray;
		gunman4Reload = gunman4Obj.GetComponent<gunmanSetup>().reloadArray;

		//initialise gunman 5
		gunman5Obj = GameObject.Find ("Gunman 5");
		gunman5Source = gunman5Obj.GetComponent<TBE_3DCore.TBE_Source>();
		gunman5Shots = gunman5Obj.GetComponent<gunmanSetup>().shotsArray;
		gunman5Reload = gunman5Obj.GetComponent<gunmanSetup>().reloadArray;

		//initialise gunman 6
		gunman6Obj = GameObject.Find ("Gunman 6");
		gunman6Source = gunman6Obj.GetComponent<TBE_3DCore.TBE_Source>();
		gunman6Shots = gunman6Obj.GetComponent<gunmanSetup>().shotsArray;
		gunman6Reload = gunman6Obj.GetComponent<gunmanSetup>().reloadArray;

		//initialise gunman 7
		gunman7Obj = GameObject.Find ("Gunman 7");
		gunman7Source = gunman7Obj.GetComponent<TBE_3DCore.TBE_Source>();
		gunman7Shots = gunman7Obj.GetComponent<gunmanSetup>().shotsArray;
		gunman7Reload = gunman7Obj.GetComponent<gunmanSetup>().reloadArray;


		
		//initialise line params
		lineNumber = 0;
		linePause = 0.1f;
		
	}
	
	// reads in a clip and returns it length to use for setting wait times
	private float getCurrentClipLength(AudioClip clip){
		return clip.length;
	}
	
	public void triggerClipRoutine(int whichRoutine){
		//Yard
		if (whichRoutine == 6 && sceneGDialoguePlayed == false){
			StartCoroutine(playSceneG(14));
			Debug.Log ("COROUTINE G");
		}
	}
	
	private void resetLogicAfterConversation(int conversation){

		if(conversation == 6){
			scriptTrigSceneG.externalCallbackDeactivate();
			sceneGDialoguePlaying = false;
			sceneGDialoguePlayed = true;
			Debug.Log("RESET G");
		}
		lineNumber = 0;
		
	}
	
	// the coroutine for the gunmen
	public IEnumerator playSceneG(int lineCount){

		while(lineNumber < lineCount){
			sceneGDialoguePlaying = true;
			sceneGDialoguePlayed = false;
			//call out name of prisoner
			charFifteenSource.PlayOneShot(charFifteenLines[lineNumber]);
			lineLength = getCurrentClipLength(charFifteenLines[lineNumber]);
			yield return new WaitForSeconds((lineLength + linePause));

			//load 7 gun reload clips into 7 different sources
			gunman1Source.clip = gunman1Reload[0];
			gunman2Source.clip = gunman2Reload[1];
			gunman3Source.clip = gunman3Reload[2];
			gunman4Source.clip = gunman4Reload[3];
			gunman5Source.clip = gunman5Reload[4];
			gunman6Source.clip = gunman6Reload[5];
			gunman7Source.clip = gunman7Reload[0];

			//play each source with some delay
			gunman1Source.PlayDelayed(0.01f);
			gunman2Source.PlayDelayed(0.01f);
			gunman3Source.PlayDelayed(0.08f);
			gunman4Source.PlayDelayed(0.10f);
			gunman5Source.PlayDelayed(0.10f);
			gunman6Source.PlayDelayed(0.20f);
			gunman7Source.PlayDelayed(0.30f);
			yield return new WaitForSeconds(2);

			//load grouped random gunfire clips into 7 sources
			gunman1Source.clip = gunman1Shots[Random.Range(0,4)];
			gunman2Source.clip = gunman2Shots[Random.Range(0,4)];
			gunman3Source.clip = gunman3Shots[Random.Range(0,4)];
			gunman4Source.clip = gunman4Shots[Random.Range(5,8)];
			gunman5Source.clip = gunman5Shots[Random.Range(5,8)];
			gunman6Source.clip = gunman6Shots[Random.Range(9,11)];
			gunman7Source.clip = gunman7Shots[Random.Range(9,11)];

			//play with some delay
			gunman1Source.PlayDelayed(0.01f);
			gunman2Source.PlayDelayed(0.04f);
			gunman3Source.PlayDelayed(0.08f);
			gunman4Source.PlayDelayed(0.10f);
			gunman5Source.PlayDelayed(0.12f);
			gunman6Source.PlayDelayed(0.16f);
			gunman7Source.PlayDelayed(0.20f);
			yield return new WaitForSeconds(2);

			lineNumber = lineNumber + 1;
		}
		
		resetLogicAfterConversation(6);
	}
	

}
