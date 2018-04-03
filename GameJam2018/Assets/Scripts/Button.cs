using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator anim;
    public bool undoCor;
    public bool undoWrong;
	public bool Enable;
	private bool on;
	private bool off;

    //Audio For Doors
    public AudioSource[] doors;
    public AudioClip[] doorClip;
    public bool doorSound;
    //Audio For Button Sound
    public AudioSource button;
    public AudioClip[] buttonClip;
    //public bool buttonSound; //We may or may not use this depending on how it sounds
    //Stuff that alex did
    public Animator[] anim2;
    public string[] CoranimOn;
	public string[] CoranimToggle;
    public string[] CoranimOff;
    public Transform[] CoractiveOn;
	public Transform[] CoractiveToggle;
	public Transform[] CoractiveOff;
    public string[] WronganimOn;
	public string[] WronganimToggle;
    public string[] WronganimOff;
    public Transform[] WrongactiveOn;
	public Transform[] WrongactiveToggle;
    public Transform[] WrongactiveOff;

	void Start () {
		Enable = false;
		on = false; //if enable is true it will be set to the oposite
		anim.SetBool ("boxPresent", true);
	}
		
	void Update () {
		if (Enable) { //set externally, usually by character controll/object controll, toggles on and off states
			Enable = false;
			if (on) {
				on = false;

				button.PlayOneShot (buttonClip [1]);//If it sounds bad put this in if
				if (undoCor) {
					UndoCorrectEffect ();				
				}
				if (doorSound) {
					doors[0].PlayOneShot (doorClip[1]);
				}
				WrongEffect ();
				anim.SetBool ("CorrectAnswer", false);
				anim.SetBool ("WrongAnswer", true);
			}
			else {
				on = true;

				button.PlayOneShot (buttonClip [0]);//If it sounds bad put this in if
				if (undoWrong) {
					UndoWrongEffect ();
				}
				if (doorSound) {
					doors [0].PlayOneShot (doorClip [0]);
				}
				CorrectEffect ();
				anim.SetBool ("CorrectAnswer", true);
				anim.SetBool ("WrongAnswer", false);
			}
		}
	}

    void CorrectEffect()
    {
		foreach (Animator anim2 in anim2) {
			foreach (string value in CoranimOn) {
				anim2.SetBool (value, true);
			}
			foreach (string value in CoranimToggle) {
				anim2.SetBool (value, !anim2.GetBool (value));
			}
			foreach (string value in CoranimOff) {
				anim2.SetBool (value, false);
			}
			foreach (Transform value in CoractiveOn) {
				value.gameObject.SetActive (true);
			}
			foreach (Transform value in CoractiveToggle) {
				value.gameObject.SetActive (!value.gameObject.activeSelf);
			}
			foreach (Transform value in CoractiveOff) {
				value.gameObject.SetActive (false);
			}
		}
    }

    void UndoCorrectEffect()
    {
		foreach (Animator anim2 in anim2) {
			foreach (string value in CoranimOn) {
				anim2.SetBool (value, false);
			}
			foreach (string value in CoranimToggle) {
				anim2.SetBool (value, !anim2.GetBool (value));
			}
			foreach (string value in CoranimOff) {
				anim2.SetBool (value, true);
			}
			foreach (Transform value in CoractiveOn) {
				value.gameObject.SetActive (false);
			}
			foreach (Transform value in CoractiveToggle) {
				value.gameObject.SetActive (!value.gameObject.activeSelf);
			}
			foreach (Transform value in CoractiveOff) {
				value.gameObject.SetActive (true);
			}
		}
    }

    void WrongEffect()
    {
		foreach (Animator anim2 in anim2) {
			foreach (string value in WronganimOn) {
				anim2.SetBool (value, true);
			}
			foreach (string value in WronganimToggle) {
				anim2.SetBool (value, !anim2.GetBool (value));
			}
			foreach (string value in WronganimOff) {
				anim2.SetBool (value, false);
			}
			foreach (Transform value in WrongactiveOn) {
				value.gameObject.SetActive (true);
			}
			foreach (Transform value in WrongactiveToggle) {
				value.gameObject.SetActive (!value.gameObject.activeSelf);
			}
			foreach (Transform value in WrongactiveOff) {
				value.gameObject.SetActive (false);
			}
		}
    }

    void UndoWrongEffect()
    {
		foreach (Animator anim2 in anim2) {
			foreach (string value in WronganimOn) {
				anim2.SetBool (value, false);
			}
			foreach (string value in WronganimToggle) {
				anim2.SetBool (value, !anim2.GetBool (value));
			}
			foreach (string value in WronganimOff) {
				anim2.SetBool (value, true);
			}
			foreach (Transform value in WrongactiveOn) {
				value.gameObject.SetActive (false);
			}
			foreach (Transform value in WrongactiveToggle) {
				value.gameObject.SetActive (!value.gameObject.activeSelf);
			}
			foreach (Transform value in WrongactiveOff) {
				value.gameObject.SetActive (true);
			}
		}
    }
}
