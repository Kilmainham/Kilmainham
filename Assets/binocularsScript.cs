using UnityEngine;
using System.Collections;

public class binocularsScript : MonoBehaviour {

	private const int ZOOM_IN_FIELD_OF_VIEW = 20;
	private const int ZOOM_OUT_FIELD_OF_VIEW = 30;

	
	public void EnableDisable (bool enable) {

		gameObject.SetActive(enable);
		EnableDisableZoom(enable);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EnableDisableZoom (bool enable) {
		int newFieldOfView;
		if (enable == true) {
			newFieldOfView = ZOOM_IN_FIELD_OF_VIEW;
		}
		else {
			newFieldOfView = ZOOM_OUT_FIELD_OF_VIEW;
		}
		Transform parentTransform = gameObject.transform.parent;
		Transform cameraRightTransform = parentTransform.FindChild("CameraRight");
		Transform cameraLeftTransform = parentTransform.FindChild("CameraLeft");
		Camera cameraRightCameraComponent = cameraRightTransform.GetComponent<Camera>();
		Camera cameraLeftCameraComponent = cameraLeftTransform.GetComponent<Camera>();
		cameraRightCameraComponent.fieldOfView = newFieldOfView;
		cameraLeftCameraComponent.fieldOfView = newFieldOfView;

	}
}
