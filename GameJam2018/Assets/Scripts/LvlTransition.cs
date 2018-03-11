using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlTransition: MonoBehaviour {
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
		transform.gameObject.SetActive (false);
	}

}
