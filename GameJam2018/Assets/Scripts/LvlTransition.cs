using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlTransition: MonoBehaviour {
	public Transform lv1;
	public Transform lv2;
	public Transform player;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			if (lv2 != null) {
				lv2.gameObject.SetActive (true);
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			if (lv1 != null) {
				lv1.gameObject.SetActive (false);
			}
			transform.gameObject.SetActive (false);
		}
	}
}
