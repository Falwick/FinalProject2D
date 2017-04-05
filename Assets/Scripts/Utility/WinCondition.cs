using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinCondition : MonoBehaviour {

	public Text winText;
	private PlayerMovement pm;

	public virtual bool playerWon
	{
		get;
		protected set;
	}

	// Use this for initialization
	void Start () {

		//winText.enabled = false;
		playerWon = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D player)
	{
		playerWon = true;
		Debug.Log ("VARIABLE PLAYER WON: " + playerWon);
		//Debug.Log ("YOU HAVE WON!!");
		//winText.enabled = true;
		//pm = player.GetComponent<PlayerMovement> ();
		//if (player != null) {
		//	pm.enabled = false;	
	}

}

