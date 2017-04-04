using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_AttackTrigger_2 : MonoBehaviour {

	[Tooltip ("Damage ammount that this player can deal")]
	public float damage = 50.0f;

	private Destructible playerDestructible;
	private bool playerClose = false;

	// Detects if an Player is close, and gets its destructible
	void OnCollisionEnter2D(Collision2D player)
	{
		if (player.collider.CompareTag ("Player")) 
		{
			playerClose = true;
			playerDestructible = player.collider.GetComponent<Destructible> ();
			Debug.Log ("Nombre del destructible: " + playerDestructible.name);
		} 
	}

	//Tells when an Player is not close anymore
	void OnTriggerExit2D (Collider2D player)
	{
		if (player.CompareTag ("Player")) 
		{
			playerClose = false;
		}
	}


	void Start () {

	}

	// check everytime if an Player is close. If yes checks If the player hits the attack button.
	// After that, deals damage to the destructible detected.
	void Update () {

		if (playerClose) 
		{					
			//Debug.Log ("GOLPEADO!!!!");
			playerDestructible.TakeDamage (damage);
			Debug.Log("Hit Points of Player: "+playerDestructible.hitPoints);
			playerClose = false;

		}
	}
}

