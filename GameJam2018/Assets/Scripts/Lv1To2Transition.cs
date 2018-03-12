using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv1To2Transition : MonoBehaviour {
	public Transform lv1;
	public Transform lv2;
	public Transform player;

	void OnTriggerEnter(Collider other) {
		lv2.gameObject.SetActive (true);
	}

	void OnTriggerExit(Collider other) {
		lv1.gameObject.SetActive (false);
		Transform spawn = lv2.GetChild (0);
		player.transform.position = spawn.position;
		transform.gameObject.SetActive (false);
	}
}
