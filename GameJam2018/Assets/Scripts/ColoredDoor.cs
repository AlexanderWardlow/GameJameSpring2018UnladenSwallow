using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredDoor : MonoBehaviour
{
	public Transform lightSource;
	public Transform door;

	void OnTriggerStay (Collider other) {
		if (other.transform == lightSource.transform) {
			door.gameObject.SetActive (false);
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.transform == lightSource.transform) {
			door.gameObject.SetActive (true);
		}
	}


}
