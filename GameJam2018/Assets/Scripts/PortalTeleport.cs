using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour {
	public Transform reciever;
	public Transform player;

	private bool playerInField = false;

	void Update () {
		if (playerInField) {
			Vector3 portalToPlayer = player.position - transform.position;
			float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
		
			//player has moved into portal, teleport
			if (dotProduct < 0f) {
				float rotDiff = Quaternion.Angle (transform.rotation, reciever.rotation);
				rotDiff += 180;
				player.Rotate (Vector3.up, rotDiff);

				Vector3 positionOffset = Quaternion.Euler (0f, rotDiff, 0f) * portalToPlayer;
				player.position = reciever.position + positionOffset;

				playerInField = false;
			}
		
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			playerInField = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Player") {
			playerInField = false;
		}
	}

}
