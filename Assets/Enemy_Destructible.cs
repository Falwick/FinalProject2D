using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Destructible : MonoBehaviour {

	public float maximumHitPoints = 100.0f;
	public float invincibilityTime = 0.5f;
	//private Animator animator;
	//private PlayerMovement movement;

	//public AudioClip Enemy_hit;
	public AudioSource auds;


	protected float lastTimeHurt;

	public virtual float hitPoints
	{
		get;
		protected set;
	}

	public virtual bool isDying
	{
		get;
		protected set;
	}

	public virtual void Start()
	{
		hitPoints = maximumHitPoints;

		//we're setting the last time hurt in the past so that we can be hurt immediately
		lastTimeHurt = Time.time - invincibilityTime;
		//animator = GetComponentInChildren<Animator> ();
		//movement = GetComponent <PlayerMovement> ();

		auds = GetComponent<AudioSource> ();
	}

	public virtual void TakeDamage( float amount )
	{
		Debug.Log ("SONIDO GOLPE");
		//auds.PlayOneShot(Enemy_hit, 1.0F);
		if (auds != null) {
			auds.Play ();
		}
		ModifyHitPoints( -amount );
	}

	public virtual void RecoverHitPoints( float amount )
	{
		ModifyHitPoints( amount );
	}

	public virtual void ModifyHitPoints( float amount )
	{
		//if we were recently hurt, we can't be hurt again, so do nothing
		if ( Time.time - lastTimeHurt < invincibilityTime && amount < 0.0f )
		{
			return;
		}

		hitPoints += amount;
		hitPoints = Mathf.Min( hitPoints, maximumHitPoints );

		if ( hitPoints <= 0.0f )
		{
			Die();
		}
	}

	public virtual void Die()
	{
		if ( isDying )
		{
			return;
		}

		isDying = true;

		//animator.SetTrigger ("playerDie");
		//movement.enabled = false;
		//Debug.Log ("DESTRUCTIBLE ENEMY");
		Object.Destroy( gameObject );
	}

}
