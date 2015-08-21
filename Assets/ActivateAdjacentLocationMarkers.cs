using UnityEngine;
using System.Collections;

public class ActivateAdjacentLocationMarkers : MonoBehaviour {
	GameObject locationMarkers;
	Transform[] locationPoints;
	FadeObjectInOut fade;
	MeshCollider coll;
	AdjacentMarkerIdentifier[] amis;
	// Use this for initialization
	void Start () {
		//find all location markers
		locationMarkers = GameObject.Find ("LocationMarkers");
		locationPoints=locationMarkers.GetComponentsInChildren<Transform> ();
		Debug.Log ("length is " + locationPoints.Length);
		//For each location marker disable the renderer and collider
		for (int i=0; i<locationPoints.Length; i++) {
			if (locationPoints[i].gameObject.name!="LocationMarkers"){//Don't add these to the parent
				locationPoints[i].gameObject.AddComponent<FadeObjectInOut>();
				fade = locationPoints[i].gameObject.GetComponent<FadeObjectInOut>();
				fade.FadeOut(0.01f);
				coll = locationPoints[i].gameObject.GetComponent<MeshCollider>();
				coll.enabled=false;
				locationPoints[i].gameObject.tag="lp"+i;
			}
		}
		GameObject firstMarker = GameObject.FindGameObjectWithTag ("lp1");
		fade = firstMarker.GetComponent<FadeObjectInOut> ();
		fade.FadeIn ();
		coll = firstMarker.GetComponent<MeshCollider> ();
		coll.enabled = true;

	}

	public void deactivateMarkers(){
		for (int i=1; i<locationPoints.Length; i++) {
			GameObject marker = locationPoints [i].gameObject;
			fade = marker.GetComponent<FadeObjectInOut> ();
			fade.FadeOut ();
			coll = marker.GetComponent<MeshCollider> ();
			coll.enabled = false;
		}		
	}

	public void activateMarkers(int i){
		Debug.Log (i);
		GameObject marker = GameObject.FindGameObjectWithTag ("lp" + i);

		amis = marker.GetComponents<AdjacentMarkerIdentifier> ();
		foreach (AdjacentMarkerIdentifier ami in amis) {
			GameObject newMarker = GameObject.FindGameObjectWithTag("lp"+ami.markerToActivate);
			Debug.Log(newMarker);
			fade = newMarker.GetComponent<FadeObjectInOut> ();
			fade.FadeIn ();
			Debug.Log(fade);
			coll = newMarker.GetComponent<MeshCollider> ();
			coll.enabled = true;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
