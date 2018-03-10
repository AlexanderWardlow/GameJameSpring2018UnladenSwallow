using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraControl : MonoBehaviour {

	public Transform playerCam;
	public Transform portalSeen;
	public Transform portalDestination;

	//public Transform portalSeenFrame;
	//public Transform portalDestinationFrame;

	void LateUpdate() {
		Vector3 playerOffsetFromPortal = playerCam.position - portalDestination.position;
		transform.position = portalSeen.position + playerOffsetFromPortal;

		float angularDifferenceBetweenPortalRotations = Quaternion.Angle (portalSeen.rotation ,portalDestination.rotation);
		Quaternion portalRotDiff = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
		Vector3 newCameraDirection = portalRotDiff * playerCam.forward;
		transform.rotation = Quaternion.LookRotation (newCameraDirection, Vector3.up);
	}
}
