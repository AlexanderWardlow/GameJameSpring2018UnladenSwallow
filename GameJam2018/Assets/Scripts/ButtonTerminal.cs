using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ButtonTerminal : MonoBehaviour {
	public Animator anim;
	public string correctCubeColor;
	void OnTriggerEnter (Collider other) {
		//FIXME need to convert the objectControl to a c# class and check if object can be picked up
		if (!anim.GetBool("boxPresent")) {
			if (other.gameObject.tag == "PickUpAble") {
				anim.SetBool ("boxPresent", true);
				if (other.gameObject.name.IndexOf(correctCubeColor) != -1) {
					anim.SetBool ("CorrectAnswer", true);
					anim.SetBool ("WrongAnswer", false);
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
}
