using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


	public Text restartText;
	public Text gameOverText;
	public Text playerWonText;


	public Destructible player;

	private bool gameOver;
	private bool restart;

	public BoxCollider2D winTrigger;
	private bool playerWin;
	public GameObject [] enemies;

	// Use this for initialization
	void Start () {

		gameOver = false;
		restart = false;
		playerWin = false;

		restartText.text = "";
		gameOverText.text = "";

		playerWonText.text = "";


		
	}
	
	// Update is called once per frame
	void Update () {


		
		if (player != null) {
			if (player.isDying == true) 
			{
				GameOver ();
				DeactivateEnemies ();
			}
		}

		playerWin = winTrigger.GetComponent<WinCondition>().playerWon;

		if (playerWin) 
		{

			playerWonText.text = "You have exit the Dungeon!!";
			restartText.text = "Press 'R' for Restart";
			restart = true;
			if (player != null) 
			{
				player.GetComponent<PlayerMovement>().enabled=false;	
				DeactivateEnemies ();
			}
		
		}
		if (restart) 
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		
	}

	public void GameOver (){
	
		gameOverText.text = "Game Over";
		restartText.text = "Press 'R' for Restart";
		gameOver = true;
		restart = true;
	}

	//public void PlayerWin()
	//{
	//	playerWin = winTrigger.GetComponent<WinCondition>().playerWon;
	//}

	public void DeactivateEnemies ()
	{
		foreach(GameObject enemy in enemies)
		{
			if (enemy != null) {
				switch (enemy.name) {
				case "SpikeMonster":
					enemy.GetComponent<MoveTowards> ().enabled = false;
					break;
				case "Enemy_red":
					enemy.GetComponent<PatrolController> ().enabled = false; 
					break;
				case "Enemy_green":
					enemy.GetComponent<PatrolController2> ().enabled = false;
					break;
				default:
					Debug.Log ("No enemies to deactivate");
					break;
				}
			}
		}
	}

}
