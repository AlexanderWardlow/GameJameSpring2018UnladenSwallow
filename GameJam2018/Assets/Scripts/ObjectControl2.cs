using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl2 : MonoBehaviour {

	private bool guiShow = false;
	public static bool pickedUp = false;
	public AudioClip openDoorSound;
	public AudioClip closeDoorSound;
	public Transform onHand;

	private GameObject objectPickedUp;
	static public Transform pickedUpObjectParent;
	private GameObject objectLookedAt;

	private RaycastHit hit;
	private Vector3 fwd;
	public float rayLength = 3.0f;

	void Start() {
		fwd = transform.forward;
		guiShow = false;
	}

	void Update() {
		fwd = transform.forward;
		if(Physics.Raycast(transform.position, transform.forward, out hit, rayLength)) {
			if(hit.collider.gameObject.tag == "OpenDoor") {
				guiShow = true;
				objectLookedAt = hit.collider.gameObject;
				if(Input.GetKeyDown("e")) {
					closeDoor(objectLookedAt);
					guiShow = false;
				}
			}

			else if(hit.collider.gameObject.tag == "ClosedDoor") {
				guiShow = true;
				objectLookedAt = hit.collider.gameObject;
				if(Input.GetKeyDown("e")) {
					openDoor(objectLookedAt);
					guiShow = false;
				}
			}

			else if(hit.collider.gameObject.tag == "LockedDoor") {
				guiShow = true;
			}

			else if (hit.collider.gameObject.tag == "PickUpAble") {
				guiShow = true;
				objectPickedUp = hit.collider.gameObject;
				if(Input.GetKeyDown("e") && (pickedUp == false)) {
					pickUp(objectPickedUp);
					pickedUp = true;
					guiShow = false;
				}

				else if(Input.GetKeyDown("e") && (pickedUp == true)) {
					drop(objectPickedUp);
					pickedUp = false;
					guiShow = false;
				}
			}

			else {
				guiShow = false;
			}

		}
	}

	void OnGUI() {
		if(Physics.Raycast(transform.position, fwd, out hit, rayLength)) {
			Rect R = new Rect ((float)(Screen.width / 2.0), (float)(Screen.height / 2.0), 100.0f, 25.0f);
			if(hit.collider.gameObject.tag == "OpenDoor") {
				if (guiShow == true) {
					GUI.Box(R, "Close Door");
				}
			}


			if(hit.collider.gameObject.tag == "ClosedDoor") {
				if (guiShow == true) {
					GUI.Box(R, "Open Door");
				}
			}

			if(hit.collider.gameObject.tag == "LockedDoor") {
				if (guiShow == true) {
					GUI.Box(R, "Door Locked");
				}
			}

			else if (hit.collider.gameObject.tag == "PickUpAble") {
				if (guiShow == true && pickedUp == false) { 
					GUI.Box(R, "Pick Up");
				}
			}
		} 
	}

	void pickUp(GameObject oPU) {
		GameObject object1;
		object1 = oPU;
		object1.layer = 9;
		object1.GetComponent<Rigidbody>().useGravity = false;
		object1.GetComponent<Rigidbody>().isKinematic = true;
		object1.transform.position = onHand.position;
		object1.transform.rotation = transform.rotation;
		pickedUpObjectParent = object1.transform.parent;
		object1.transform.parent = GameObject.Find("Player").transform;
		object1.transform.parent= GameObject.Find("FirstPersonCharacter").transform;
	}

	public static void drop(GameObject object1) {
		object1.layer = 0;
		object1.transform.parent = pickedUpObjectParent;
		object1.GetComponent<Rigidbody>().useGravity = true;
		object1.GetComponent<Rigidbody>().isKinematic = false;
	}

	void openDoor(GameObject door) {
		door.GetComponent<Animation>().Play("DoorOpen");
		door.GetComponent<AudioSource>().PlayOneShot(openDoorSound);
		objectLookedAt.tag = "OpenDoor";
	}

	void closeDoor(GameObject door) {
		door.GetComponent<Animation>().Play("DoorClose");
		door.GetComponent<AudioSource>().PlayOneShot(closeDoorSound);
		objectLookedAt.tag = "ClosedDoor";
	}

}
	