using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reSpawn : MonoBehaviour {
	public Transform lv2;
	public Transform player;

	void OnTriggerExit(Collider other) {
		Transform spawn = lv2.GetChild (0);
		player.transform.position = spawn.position;
	}
}
