using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinCondition : MonoBehaviour {

	public Text winText;

	// Use this for initialization
	void Start () {

		winText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D player)
	{
		Debug.Log ("YOU HAVE WON!!");
		winText.enabled = true;
	}
}
