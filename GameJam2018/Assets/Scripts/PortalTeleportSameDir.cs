using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleportSameDir : MonoBehaviour {
	public Transform reciever;
	public Transform player;
	public Transform playerParent;

	private bool playerInField = false;

	void Update () {
		if (playerInField) {
			playerInField = false;
			print ("ThisIsRunning");
			Vector3 portalToPlayer = playerParent.position - transform.position;
			float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
		
			//player has moved into portal, teleport
			if (dotProduct < 0f) {
			    //Vector3 angleAdjust = player.eulerAngles + 0f * Vector3.up;
				playerParent.Rotate(Vector3.up, 180);
				Vector3 positionOffset = portalToPlayer;
				playerParent.position = reciever.position + positionOffset;
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
