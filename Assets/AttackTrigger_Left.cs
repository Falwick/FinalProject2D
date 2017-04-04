using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger_Left : MonoBehaviour {

	[Tooltip ("Damage ammount that this player can deal")]
	public float damage = 50.0f;

	private Enemy_Destructible enemyDestructible;
	private bool enemyClose = false;

	public GameObject animatedObject;
	private Animator animator;

	public AudioSource attackSound;

	// Detects if an enemy is close, and gets its destructible
	void OnTriggerEnter2D(Collider2D enemy)
	{
		if (enemy.CompareTag ("Enemy")) 
		{
			enemyClose = true;
			enemyDestructible = enemy.GetComponent<Enemy_Destructible> ();
			Debug.Log ("Nombre del destructible: " + enemyDestructible.name);
		} 
	}

	//Tells when an enemy is not close anymore
	void OnTriggerExit2D (Collider2D enemy)
	{
		if (enemy.CompareTag ("Enemy")) 
		{
			enemyClose = false;
		}
	}


	void Start () {
		animator = animatedObject.GetComponent<Animator> ();
	}


	// check everytime if an enemy is close. If yes checks If the player hits the attack button.
	// After that, deals damage to the destructible detected.
	void Update () {

		if (Input.GetButtonDown ("Attack")) {

			if (animator != null) {

				if (attackSound != null) {
					attackSound.Play ();
				}

				animator.SetTrigger ("playerAttack");

			}

			if (enemyClose) 
			{		

				//Debug.Log ("GOLPEADO!!!!");
				enemyDestructible.TakeDamage (damage);
				Debug.Log("Hit Points of Enemy: "+enemyDestructible.hitPoints);
			}
		}
	}
}
