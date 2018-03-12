using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour {

	public AudioSource aS;
	public AudioClip song;
	private bool isFirstTime = true;

	// Use this for initialization
	void OnTriggerEnter(){
		if (isFirstTime) {
			aS.clip = song;
			aS.loop = true;
			aS.Play ();	
			isFirstTime = false;
		}

	}
}
