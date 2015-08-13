using UnityEngine;
using System.Collections;

public class TriggerNewFlyingPath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name.Equals("Player")) {
			GameObject butterfly = GameObject.Find ("butterfly");
			FollowFlyingPath followFlyingPathScript = butterfly.GetComponent<FollowFlyingPath>();
			followFlyingPathScript.SetFlyingPath(gameObject.transform.parent.gameObject);
		}
	}
}
