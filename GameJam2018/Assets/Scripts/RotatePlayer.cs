using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour {

	public float rotationSpeed = 8.0f;
	public float cameraSpeed = 4.0f;
	public Transform playerCam;

	private float verticalRotation;

	void FixedUpdate () {
		float h = Input.GetAxis ("Mouse X") * 2;
		transform.Rotate(0, h, 0);
		verticalRotation -= Input.GetAxis ("Mouse Y") * 2;
		verticalRotation = Mathf.Clamp (verticalRotation, -90, 90);
		playerCam.localRotation = Quaternion.Euler (verticalRotation, 0, 0);
	}
}
