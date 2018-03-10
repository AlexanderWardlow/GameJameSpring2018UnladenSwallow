using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour {

	public float rotationSpeed = 10.0f;
	public float cameraSpeed = 1000f;
	public Transform playerCam;


	void FixedUpdate () {
		float h = rotationSpeed * Input.GetAxis ("Mouse X");
		transform.Rotate(0, h, 0);
		float v = cameraSpeed * Input.GetAxis ("Mouse Y");
		v *= Time.deltaTime*2;
		playerCam.Rotate(-v,0,0);
	}
}
