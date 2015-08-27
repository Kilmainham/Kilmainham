using UnityEngine;
using System.Collections;

public class binocularsScript : MonoBehaviour {

	private const float ZOOM_IN_FIELD_OF_VIEW = 15f;
	private const float ZOOM_OUT_FIELD_OF_VIEW = 30f;
	private float newFieldOfView;

	
	public void EnableDisable (bool enable) {

		gameObject.SetActive(enable);
		EnableDisableZoom(enable);
	}
	
	public void EnableDisableZoom (bool enable) {

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
