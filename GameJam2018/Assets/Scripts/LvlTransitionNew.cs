using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlTransitionNew: MonoBehaviour {
	public Transform lv1;
	public Transform lv2;
	public Transform player;
	public Renderer R;

	private bool enable;

	void Start () {
		enable = false;
	}

	void Update () {
		if (R.isVisible) {
			enable = true;
		}
		else {
			enable = false;
		}
	}


	void OnTriggerEnter(Collider other) {
		if (enable) {
			//if (lv2 != null) {
				if (other.tag == "Player") {
					lv2.gameObject.SetActive (true);
				}
			//}
		}
	}

	void OnTriggerExit(Collider other) {
		if (enable) {
			if (other.tag == "Player") {
				//if (lv1 != null) {
					lv1.gameObject.SetActive (false);
				//}
				transform.gameObject.SetActive (false);
			}
		}
	}
}
