using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	// Use this for initialization
	private bool attacking = false;
	private float attackTimer= 0.0f;
	private float attackCd = 0.3f;

	public Collider2D attackTrigger;

	void Awake () {
		
		attackTrigger.enabled = false;

	}


	void Update () 
	{
		if (Input.GetKeyDown ("p") && !attacking) 
		{

			Debug.Log ("Entra a update de player attack");
			attacking = true;

			attackTimer = attackCd;
			attackTrigger.enabled = true;

			if (attacking)
			{
				Debug.Log ("Entra a attacking!!");
				if (attackTimer > 0) {
					attackTimer -= Time.deltaTime;
					attacking = false;
				} 
				else 
				{
					Debug.Log ("Entra al else de attacking");
					attacking = false;
					attackTrigger.enabled = false;
				}

			}
		
		}
	}




	/*public void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log ("Enter Hit!!!");
		hit = Input.GetButtonDown ("Attack");
		if (hit) {
			Debug.Log ("Hit Pressed!!!");
		
		}

		PickupGetter ninjaKeys = collision.collider.GetComponent<PickupGetter> ();
		if (ninjaKeys.keysCollected >= 1) 
		{
			Destroy (this.gameObject);
		
	}}*/
}
