using UnityEngine;
using System.Collections;

public class Scene2ChallengeMarker : MonoBehaviour {


	public void challengeCompleted(){
		GameObject penultimateMarker = GameObject.Find ("9");
		if (penultimateMarker) {
			penultimateMarker.AddComponent<AdjacentMarkerIdentifier>();
			AdjacentMarkerIdentifier[] amis = penultimateMarker.GetComponents<AdjacentMarkerIdentifier>();
			amis[amis.Length-1].markerToActivate=10;
		}
	}

}
