using UnityEngine;
using System.Collections;

public class rotateLight : MonoBehaviour {
	GameObject dlight;
	Transform trans;
	Vector3 rotationAngle = new Vector3(0f,0.1f,0f);
	// Use this for initialization
	void Start () {
		dlight = GameObject.Find ("RotateLight");
		trans = dlight.GetComponent<Transform> ();
	

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("W = "+ trans.transform.rotation.w+ " and Y = "+trans.transform.rotation.y);
		if (trans.transform.rotation.y < 0.78f && trans.transform.rotation.w > 0.62f) {
			trans.Rotate (rotationAngle);
		} else {
			Destroy(this);
		}
	}
}
