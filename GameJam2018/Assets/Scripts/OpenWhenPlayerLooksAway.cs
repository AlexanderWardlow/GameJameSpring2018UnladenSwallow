using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWhenPlayerLooksAway : MonoBehaviour {

	public Animator A;
	public string ifSeen;
	public string ifNotSeen;
	public bool doToggle;
	private Renderer R;

	// Use this for initialization
	void Start () {
		R = transform.gameObject.GetComponent<Renderer> ();
	}
	
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
