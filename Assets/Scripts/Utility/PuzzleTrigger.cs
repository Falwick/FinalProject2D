using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour {

	public BoxCollider2D door;
	public PickupGetter getter;

	// Use this for initialization
	void Start () {
		door = GetComponent<BoxCollider2D>();
		getter = GetComponent<PickupGetter> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (getter.keysCollected >= 1) {
			Debug.Log ("Door Opened!!!!");
		}
		
	}
		
}
