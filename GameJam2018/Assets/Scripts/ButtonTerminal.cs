using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTerminal : MonoBehaviour {
	public Animator anim;
	public string correctCubeColor;
	public bool cantPickupAfter;

	public Animator[] anim2;
	public string[] animOn;
	public string[] animOff;
	public Transform[] activeOn;
	public Transform[] activeOff;

	void OnTriggerEnter (Collider other) {
		//FIXME need to convert the objectControl to a c# class and check if object can be picked up
		if (!anim.GetBool("boxPresent")) {
			if (other.gameObject.tag == "PickUpAble") {
				if (cantPickupAfter) {
					other.gameObject.tag = "Untagged";
				}

				anim.SetBool ("boxPresent", true);
				if (other.gameObject.name.IndexOf(correctCubeColor) != -1) {
					anim.SetBool ("CorrectAnswer", true);
					anim.SetBool ("WrongAnswer", false);
					CorrectEffect ();

				}
				else {
					anim.SetBool ("CorrectAnswer", false);
					anim.SetBool ("WrongAnswer", true);
				}
			}
		}
	}

	void OnTriggerExit (Collider other) {
			if (other.gameObject.tag == "PickUpAble") {
				anim.SetBool ("CorrectAnswer", false);
				anim.SetBool ("WrongAnswer", false);
				anim.SetBool ("boxPresent", false);
			}
	}

	void CorrectEffect() {
		foreach(string value in animOn) {
			anim2[0].SetBool (value, true);
		}
		foreach(string value in animOff) {
			anim2[0].SetBool (value, false);
		}
		foreach(Transform value in activeOn) {
			value.gameObject.SetActive (true);
		}
		foreach(Transform value in activeOff) {
			value.gameObject.SetActive (false);
		}
	}
}
