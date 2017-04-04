using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

	//public PickupGetter getter;
	public BoxCollider2D winTrigger;

	// Use this for initialization
	void Start () {

	//	getter = GetComponent<PickupGetter> ();
	//	door = GetComponent<Rigidbody2D> ();
		winTrigger.enabled= false;
		
	}
	
	// Update is called once per frame

	public void OnCollisionEnter2D(Collision2D collision)
	{
		PickupGetter ninjaKeys = collision.collider.GetComponent<PickupGetter> ();
		if (ninjaKeys.keysCollected >= 1) 
		{
			winTrigger.enabled = true;
			Destroy (this.gameObject);
		}
	}

	void Update () {
		
	}
}
