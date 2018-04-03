using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl7BlueRoomSetupOnEntry : MonoBehaviour {

	public Animator door1;
	public Animator door2;
	public Animator door3;
	public Animator door4;

	void Start () {
		door1.SetBool ("open", false);
		door3.SetBool ("open", false);
	}

}
