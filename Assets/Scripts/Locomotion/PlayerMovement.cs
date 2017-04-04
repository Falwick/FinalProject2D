using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed = 5.0f;
	//private Animator animator;
	private SpriteRenderer sr;
	//private bool changeDirection;
	private AttackTrigger attackTrigger_Right;
	private AttackTrigger_Left attackTrigger_Left;


	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		//animator = GetComponent<Animator> ();
		sr = GetComponentInChildren<SpriteRenderer> ();
		//changeDirection = false;

		attackTrigger_Right =GetComponentInChildren<AttackTrigger>();
		attackTrigger_Left =GetComponentInChildren<AttackTrigger_Left>();
		attackTrigger_Right.enabled = true;
		attackTrigger_Left.enabled = false;

	}
	
	// Update is called once per frame
	void Update () 
	{

		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");



		/*Debug.Log ("Horizontal: " + horizontal);
		Debug.Log ("Vertical: " + vertical);
		Debug.Log ("Magnitud: " + movementVector.x);*/

		if (Input.GetKey(KeyCode.LeftArrow)){
			sr.flipX = true;
			attackTrigger_Right.enabled = false;
			attackTrigger_Left.enabled = true;
		}

		if (Input.GetKey(KeyCode.RightArrow)){
			sr.flipX = false;
			attackTrigger_Right.enabled = true;
			attackTrigger_Left.enabled= false;
		}
			



		if (horizontal != 0) {
			vertical = 0;
		}
		Vector2 movementVector = new Vector2 (horizontal, vertical);


			if (movementVector != Vector2.zero) {
				rb.MovePosition (rb.position + movementVector * speed * Time.deltaTime);



			

		}
	}
}
