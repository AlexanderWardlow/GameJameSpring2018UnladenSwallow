using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reStateObject_Permenance1 : MonoBehaviour {

	public Transform initialState;
	public Transform finalState;
	public Transform player;
	private BoxCollider bxCol;
	private MeshRenderer mRend;

	public float maxDist;
	public float minDist;
	public float distanceToPlayer;
	public bool finalStateActive;
	public bool initialStateActive;

	// Use this for initialization
	void Start () {
		bxCol = transform.gameObject.GetComponent<BoxCollider> ();
		mRend = transform.gameObject.GetComponent<MeshRenderer> ();
		setInitialState ();
	}
	
	// Update is called once per frame
	void Update () {
		distanceToPlayer = Vector3.Distance (finalState.position, player.position);
		checkPlayerDist ();
	}

	void checkPlayerDist () {
		if (distanceToPlayer <= maxDist) {
			if (distanceToPlayer >= minDist) {
				reState ();
			} 
			else {
				setFinalState ();
			}
		}
		else {
			setInitialState ();
		}
	}

	void reState () {
		bxCol.enabled = true;
		mRend.enabled = true;
		float progresion = maxDist - distanceToPlayer;
		float total = maxDist - minDist;
		float multiplier = progresion / total;

		rePosition (multiplier);
		reSize (multiplier);
	}

	void reSize (float multiplier) {
		Vector3 scaleDiff = finalState.localScale - initialState.localScale;
		Vector3 scaleAdjust = scaleDiff * multiplier;
		transform.localScale = initialState.localScale + scaleAdjust;
	}

	void rePosition (float multiplier) {
		Vector3 posDiff = finalState.position - initialState.position;
		Vector3 positionAdjust = posDiff * multiplier;
		transform.position = initialState.position + positionAdjust;
	}

	void setFinalState () {
		transform.position = finalState.position;
		transform.localScale = finalState.localScale;
		bxCol.enabled = finalStateActive;
		mRend.enabled = finalStateActive;
	}

	void setInitialState () {
		transform.position = initialState.position;
		transform.localScale = initialState.localScale;
		bxCol.enabled = initialStateActive;
		mRend.enabled = initialStateActive;
	}
}
