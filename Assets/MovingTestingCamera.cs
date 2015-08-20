using UnityEngine;
using System.Collections;

public class MovingTestingCamera : MonoBehaviour {

	//Quaternion targetRotation;

	//float speed = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		/*GameObject leftCamera = GameObject.Find("CameraLeft");
		Camera cameraComponent = leftCamera.GetComponent(typeof(Camera));
		Ray ray = cameraComponent.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, hit, 1200)) {
			targetRotation = Quaternion.LookRotation(hit.point - gameObject.transform.position);
		}
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);*/
		if (Input.GetKey("a")){
			Quaternion target = Quaternion.Euler(transform.rotation.x, transform.rotation.y+1, transform.rotation.z);
			transform.rotation = target;
			//transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime *2.0f);
			//transform.localRotation = new Vector3(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z+1);
			print("space key was pressed");
			
		}if (Input.GetKey("d")){
			Quaternion target = Quaternion.Euler(transform.rotation.x, transform.rotation.y-1, transform.rotation.z);
			transform.rotation = target;
			//transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime *2.0f);
			//transform.localRotation = new Vector3(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z+1);
			print("space key was pressed");
			
		}if (Input.GetKey("w")){
			Quaternion target = Quaternion.Euler(transform.rotation.x+1, transform.rotation.y, transform.rotation.z);
			transform.rotation = target;
			//transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime *2.0f);
			//transform.localRotation = new Vector3(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z+1);
			print("space key was pressed");
			
		}if (Input.GetKey("s")){
			Quaternion target = Quaternion.Euler(transform.rotation.x-1, transform.rotation.y, transform.rotation.z);
			transform.rotation = target;
			//transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime *2.0f);
			//transform.localRotation = new Vector3(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z+1);
			print("space key was pressed");
			
		}
	}

}
