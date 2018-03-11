using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv1To2Transition : MonoBehaviour {
	public Transform lv1;
	public Transform lv2;
	public Transform player;
	public AudioSource musicAS;
	public AudioClip Song;

	void OnTriggerEnter(Collider other) {
		lv1.gameObject.SetActive (false);
		musicAS.PlayOneShot (Song);
	}

	void OnTriggerExit(Collider other) {
		lv2.gameObject.SetActive (true);
		Transform spawn = lv2.GetChild (0);
		player.transform.position = spawn.position;
		transform.gameObject.SetActive (false);
	}
}
