using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWhenPlayerLooksAway : MonoBehaviour {

	public Animator A;
	public string ifSeen;
	public string ifNotSeen;
	public bool doToggle;
	public Renderer R;
	
	// Update is called once per frame
	void Update () {
		if (R.isVisible) {
			A.SetBool(ifSeen,true);
			if (doToggle) {
				A.SetBool(ifNotSeen,false);
			}
		}
		else {
			A.SetBool(ifNotSeen,true);
			if (doToggle) {
				A.SetBool(ifSeen,false);
			}
		}
	}
}
