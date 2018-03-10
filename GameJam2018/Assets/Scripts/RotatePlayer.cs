using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour {

	public float rotationSpeed = 500.0f;
	public float cameraSpeed = 10f;
	public Transform playerCam;

	private float verticalRotation;

	void FixedUpdate () {
		float h = rotationSpeed * Input.GetAxis ("Mouse X");
		transform.Rotate(0, h, 0);
		verticalRotation -= Input.GetAxis ("Mouse Y") * 5f;
		verticalRotation = Mathf.Clamp (verticalRotation, -90, 90);
		playerCam.localRotation = Quaternion.Euler (verticalRotation, 0, 0);
	}
}
