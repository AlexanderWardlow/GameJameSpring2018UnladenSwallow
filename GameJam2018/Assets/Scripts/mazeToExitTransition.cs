using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazeToExitTransition : MonoBehaviour {
	public Transform lv1;
	public Transform lv2;
	public Transform player;

	void OnTriggerEnter(Collider other) {
		lv1.gameObject.SetActive (false);
	}

	void OnTriggerExit(Collider other) {
		lv2.gameObject.SetActive (true);
		transform.gameObject.SetActive (false);
	}

}
